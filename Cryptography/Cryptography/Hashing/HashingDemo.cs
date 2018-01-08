using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.Hashing
{
    public class HashingDemo
    {
        public static byte[] ComputerHashSha1(byte[] data)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashSha256(byte[] data)
        {
            using (var sha1 = SHA256.Create())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashSha512(byte[] data)
        {
            using (var sha1 = SHA512.Create())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static byte[] ComputerHashMd5(byte[] data)
        {
            using (var sha1 = MD5.Create())
            {
                return sha1.ComputeHash(data);
            }
        }

        public static void Demo()
        {
            const string originalMessage = "Original message to hash";
            const string originalMessage2 = "This is another message to hash";

            Console.WriteLine($"Original message1 : {originalMessage}");
            Console.WriteLine($"Original message2 : {originalMessage2}");

            var md5HashedMessage1 = ComputerHashMd5(Encoding.UTF8.GetBytes(originalMessage));
            var md5HashedMessage2 = ComputerHashMd5(Encoding.UTF8.GetBytes(originalMessage2));

            var sha1HashedMessage1 = ComputerHashSha1(Encoding.UTF8.GetBytes(originalMessage));
            var sha1HashedMessage2 = ComputerHashSha1(Encoding.UTF8.GetBytes(originalMessage2));

            var sha256HashedMessage1 = ComputerHashSha256(Encoding.UTF8.GetBytes(originalMessage));
            var sha256HashedMessage2 = ComputerHashSha256(Encoding.UTF8.GetBytes(originalMessage2));

            var sha512HashedMessage1 = ComputerHashSha512(Encoding.UTF8.GetBytes(originalMessage));
            var sha512HashedMessage2 = ComputerHashSha512(Encoding.UTF8.GetBytes(originalMessage2));

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