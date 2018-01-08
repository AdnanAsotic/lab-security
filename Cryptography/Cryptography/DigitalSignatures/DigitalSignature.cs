using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.DigitalSignatures
{
    internal class DigitalSignature
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] SignData(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        public bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(_publicKey);

                var rsaFormatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.VerifySignature(hashOfDataToSign, signature);
            }
        }

        public static void Demo()
        {
            var document = Encoding.UTF8.GetBytes("Document to sign");
            byte[] hashedDocument;

            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(document);
            }

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            var signature = digitalSignature.SignData(hashedDocument);

            var verified = digitalSignature.VerifySignature(hashedDocument, signature);

            Console.WriteLine(verified);
        }
    }
}