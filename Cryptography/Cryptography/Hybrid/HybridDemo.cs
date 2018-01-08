using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Cryptography.Asymetric;

namespace Cryptography.Hybrid
{
    internal class HybridDemo
    {
        public static void Demo()
        {
            const string original = "Very secret and important information that can not fall.";

            var hybrid = new HybridEncryption();

            var rsaParams = new RsaWithRsaParameterKey();
            rsaParams.AssignNewKey();

            Console.WriteLine("Hybrid encryption with integrity check.");

            try
            {
                var encrypted = hybrid.Encrypt(Encoding.UTF8.GetBytes(original), rsaParams);
                var decrypted = hybrid.Decrypt(encrypted, rsaParams);

                Console.WriteLine($"Original: {original}");
                Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}