using System;
using System.Security.Cryptography;

namespace Cryptography.Randomizing
{
    /// <summary>
    /// Best practice
    /// </summary>
    public static class RngCryptoServiceProviderDemo
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static void Test()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random number {i} : {Convert.ToBase64String(GenerateRandomNumber(32))}");
            }
        }
    }
}