using System;
using System.Security.Cryptography;
using System.Text;
using Cryptography.Randomizing;

namespace Cryptography.Passwords
{
    internal class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            return RngCryptoServiceProviderDemo.GenerateRandomNumber(32);
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
            {
                return rfc2898.GetBytes(32);
            }
        }

        public static void Demo()
        {
            const string password = "v3ryC0mpl3xP455w0rd";
            byte[] salt = GenerateSalt();

            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            var hashedPassword1 = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt, 50000);

            Console.WriteLine($"Hashed: {Convert.ToBase64String(hashedPassword1)}");
        }
    }
}