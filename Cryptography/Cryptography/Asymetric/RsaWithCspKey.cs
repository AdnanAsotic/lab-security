using System.Security.Cryptography;

namespace Cryptography.Asymetric
{
    internal class RsaWithCspKey
    {
        const string ContainerName = "MyContainer";

        public void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName};
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp =  false};
            rsa.Clear();
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] cipherBytes;

            var cspParameters = new CspParameters() { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParameters))
            {
                cipherBytes = rsa.Encrypt(data, false);
            }

            return cipherBytes;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] plain;

            var cspParameters = new CspParameters() { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParameters))
            {
                plain = rsa.Decrypt(data, false);
            }

            return plain;
        }
    }
}