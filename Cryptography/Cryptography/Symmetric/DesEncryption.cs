using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Cryptography.Randomizing;

namespace Cryptography.Symmetric
{
    internal class DesEncryption
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            return RngCryptoServiceProviderDemo.GenerateRandomNumber(length);
        }

        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                using (var ms = new MemoryStream())
                {
                    var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();

                    return ms.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                using (var ms = new MemoryStream())
                {
                    var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();

                    return ms.ToArray();
                }
            }
        }

        public static void Demo()
        {
            var des = new DesEncryption();
            var key = GenerateRandomNumber(8);
            var iv = GenerateRandomNumber(8);
            const string original = "Text to encrypt";

            var encrypted = des.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = des.Decrypt(encrypted, key, iv);

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrpyted: {Encoding.UTF8.GetString(decrypted)}");
        }
    }
}