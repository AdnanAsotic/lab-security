using System.Security.Cryptography;

namespace Cryptography.Asymetric
{
    /// <summary>
    /// in memory
    /// </summary>
    internal class RsaWithRsaParameterKey
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

        public byte[] Encrypt(byte[] data)
        {
            byte[] cipherBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);
                cipherBytes = rsa.Encrypt(data, true);
            }

            return cipherBytes;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);
                plain = rsa.Decrypt(data, true);
            }

            return plain;
        }
    }
}