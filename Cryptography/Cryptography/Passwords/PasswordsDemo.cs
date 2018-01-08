using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Cryptography.Hashing;
using Cryptography.Randomizing;

namespace Cryptography.Passwords
{
    internal class PasswordsDemo
    {
        public static byte[] GenerateSalt()
        {
            return RngCryptoServiceProviderDemo.GenerateRandomNumber(32);
        }

        /// <summary>
        /// Extend first by last
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static byte[] Combine(byte[] first, byte[] last)
        {
            var ret = new byte[first.Length + last.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(last, 0, ret, first.Length, last.Length);

            return ret;
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(toBeHashed, salt));
            }
        }

        public static void Demo()
        {
            const string password = "v3ryC0mpl3xP455w0rd";
            byte[] salt = GenerateSalt();

            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            var hashedPassword1 = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);

            Console.WriteLine($"Hashed: {Convert.ToBase64String(hashedPassword1)}");
        }
    }
}