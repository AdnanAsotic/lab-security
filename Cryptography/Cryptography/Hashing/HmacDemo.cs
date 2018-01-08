using System;
using System.Security.Cryptography;
using System.Text;
using Cryptography.Randomizing;

namespace Cryptography.Hashing
{
    internal class HmacDemo
    {
        private const int KeySize = 32;

        public static byte[] GenerateKey() => 
            RngCryptoServiceProviderDemo.GenerateRandomNumber(KeySize);

        public static byte[] ComputerHashSha1(byte[] data, byte[] key)
        {
            using (var sha1 = new HMACSHA1(key))
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashSha256(byte[] data, byte[] key)
        {
            using (var sha1 = new HMACSHA256(key))
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashSha512(byte[] data, byte[] key)
        {
            using (var sha1 = new HMACSHA512(key))
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashMd5(byte[] data, byte[] key)
        {
            using (var sha1 = new HMACMD5(key))
            {
                return sha1.ComputeHash(data);
            }
        }

        public static void Demo()
        {
            var key = GenerateKey();

            const string originalMessage = "Original message to hash";
            const string originalMessage2 = "This is another message to hash";

            Console.WriteLine($"Original message1 : {originalMessage}");
            Console.WriteLine($"Original message2 : {originalMessage2}");

            var md5HashedMessage1 = ComputerHashMd5(Encoding.UTF8.GetBytes(originalMessage), key);
            var md5HashedMessage2 = ComputerHashMd5(Encoding.UTF8.GetBytes(originalMessage2), key);

            var sha1HashedMessage1 = ComputerHashSha1(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha1HashedMessage2 = ComputerHashSha1(Encoding.UTF8.GetBytes(originalMessage2), key);

            var sha256HashedMessage1 = ComputerHashSha256(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha256HashedMessage2 = ComputerHashSha256(Encoding.UTF8.GetBytes(originalMessage2), key);

            var sha512HashedMessage1 = ComputerHashSha512(Encoding.UTF8.GetBytes(originalMessage), key);
            var sha512HashedMessage2 = ComputerHashSha512(Encoding.UTF8.GetBytes(originalMessage2), key);

            Console.WriteLine();

            Console.WriteLine("MD5 hashes");

            Console.WriteLine($"Message1: {Convert.ToBase64String(md5HashedMessage1)}");
            Console.WriteLine($"Message2: {Convert.ToBase64String(md5HashedMessage2)}");

            Console.WriteLine("SHA1 hashes");

            Console.WriteLine($"Message1: {Convert.ToBase64String(sha1HashedMessage1)}");
            Console.WriteLine($"Message2: {Convert.ToBase64String(sha1HashedMessage2)}");

            Console.WriteLine("SHA256 hashes");

            Console.WriteLine($"Message1: {Convert.ToBase64String(sha256HashedMessage1)}");
            Console.WriteLine($"Message2: {Convert.ToBase64String(sha256HashedMessage2)}");

            Console.WriteLine("SHA512 hashes");

            Console.WriteLine($"Message1: {Convert.ToBase64String(sha512HashedMessage1)}");
            Console.WriteLine($"Message2: {Convert.ToBase64String(sha512HashedMessage2)}");
        }
    }
}