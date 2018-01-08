using System.Security.Cryptography;
using Cryptography.Asymetric;
using Cryptography.DigitalSignatures;
using Cryptography.Symmetric;

namespace Cryptography.Hybrid
{
    internal class HybridEncryption
    {
        private readonly AesEncryption _aes;
        private readonly DigitalSignature _digitalSignature;

        public HybridEncryption()
        {
            _aes = new AesEncryption();
            _digitalSignature = new DigitalSignature();
            _digitalSignature.AssignNewKey();
        }

        public EncryptedPacket Encrypt(byte[] original, RsaWithRsaParameterKey rsaParams)
        {
            var sessionKey = AesEncryption.GenerateRandomNumber(32);
            var encryptedPacket = new EncryptedPacket {Iv = AesEncryption.GenerateRandomNumber(16)};

            encryptedPacket.EncryptedData = _aes.Encrypt(original, sessionKey, encryptedPacket.Iv);
            encryptedPacket.EncryptedSessionKey = rsaParams.Encrypt(sessionKey);

            using (var hmac = new HMACSHA256(sessionKey))
            {
                encryptedPacket.Hmac = hmac.ComputeHash(encryptedPacket.EncryptedData);
            }

            encryptedPacket.Signature = _digitalSignature.SignData(encryptedPacket.Hmac);

            return encryptedPacket;
        }

        public byte[] Decrypt(EncryptedPacket packet, RsaWithRsaParameterKey rsaParams)
        {
            var decriptedSessionKey = rsaParams.Decrypt(packet.EncryptedSessionKey);

            using (var hmac = new HMACSHA256(decriptedSessionKey))
            {
                var hmacToCheck = hmac.ComputeHash(packet.EncryptedData);

                if (!Compare(packet.Hmac, hmacToCheck))
                {
                    throw new CryptographicException("HMAC for decription doesn't match");
                }

                if (!_digitalSignature.VerifySignature(packet.Hmac, packet.Signature))
                {
                    throw new CryptographicException("Digital signature cannot be verified.");
                }
            }

            return _aes.Decrypt(packet.EncryptedData, decriptedSessionKey, packet.Iv);
        }

        private static bool Compare(byte[] array1, byte[] array2)
        {
            var result = array1.Length == array2.Length;

            for (var i = 0; i < array1.Length && i < array2.Length; ++i)
            {
                result &= array1[i] == array2[i];
            }

            return result;
        }
    }
}