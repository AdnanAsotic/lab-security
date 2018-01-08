using System;

namespace Cryptography.Randomizing
{
    /// <summary>
    /// Deterministic
    /// </summary>
    public static class RandomDemo
    {
        public static void Test()
        {
            var rnd = new Random(250);

            for (var ctr = 0; ctr < 10; ctr++)
            {
                Console.WriteLine("{0}   ", rnd.Next(-10, 11));
            }
        }
    }
}