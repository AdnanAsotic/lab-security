using System;
using System.Text;

namespace Cryptography.Asymetric
{
    public class AsymetricDemo
    {
        public static void Demo()
        {
            var data = "Hello You";
            var publicPath = "E:/Dev/public.xml";
            var privatePath = "E:/Dev/private.xml";

            var demo1 = new RsaWithXmlKey();
            demo1.AssignNewKey(publicPath, privatePath);

            var bData = Encoding.UTF8.GetBytes(data);

            var cipher = demo1.Encrypt(publicPath, bData);
            var plain = demo1.Decrypt(privatePath, cipher);
            Console.WriteLine($"{Encoding.UTF8.GetString(plain)}");
        }
    }
}