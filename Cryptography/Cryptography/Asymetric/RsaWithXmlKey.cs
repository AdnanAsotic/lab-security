using System.IO;
using System.Security.Cryptography;

namespace Cryptography.Asymetric
{
    internal class RsaWithXmlKey
    {
        public void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                var publicKeyFolder = Path.GetDirectoryName(publicKeyPath);
                var privateKeyFolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyFolder))
                {
                    Directory.CreateDirectory(publicKeyFolder);
                }
                if (!Directory.Exists(privateKeyFolder))
                {
                    Directory.CreateDirectory(privateKeyFolder);
                }

                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }

        public byte[] Encrypt(string publickeyPath, byte[] data)
        {
            byte[] cipherBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publickeyPath));
                cipherBytes = rsa.Encrypt(data, false);
            }

            return cipherBytes;
        }

        public byte[] Decrypt(string privateKeyPath, byte[] data)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));
                plain = rsa.Decrypt(data, false);
            }

            return plain;
        }
    }
}