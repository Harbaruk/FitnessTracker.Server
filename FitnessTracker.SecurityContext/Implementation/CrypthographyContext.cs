using CryptSharp.Utility;
using FitnessTracker.SecurityContext.Abstraction;
using System;
using System.IO;
using System.Security.Cryptography;

namespace FitnessTracker.SecurityContext.Implementation
{
    public class CrypthographyContext : ICrypthographyContext
    {
        public byte[] Hash(byte[] value, byte[] salt)
        {
            if (null == salt || null == value)
            {
                throw new ArgumentNullException();
            }
            // Key length should be exactly 255 to have AES-encrypted result as length 1024
            return SCrypt.ComputeDerivedKey(value, salt, 8192, 8, 1, null, 255);
        }

        public byte[] SymmetricEncode(byte[] value, byte[] key, byte[] initializationVector)
        {
            if (null == value || null == key || null == initializationVector)
            {
                throw new ArgumentNullException();
            }

            byte[] encrypted;
            using (Aes aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(value, 0, value.Length);
                        encrypted = memoryStream.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public byte[] GenerateRandomBytes(int size)
        {
            if (size < 1)
            {
                throw new InvalidOperationException();
            }

            byte[] data = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(data);
            }

            return data;
        }

        public string GenerateRandomPassword(int length, char[] allowedCharacters)
        {
            if (null == allowedCharacters || 0 == allowedCharacters.Length)
            {
                throw new ArgumentException(string.Empty, "allowedCharacters");
            }
            if (length < 1)
            {
                throw new InvalidOperationException();
            }

            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = allowedCharacters[GetStrongRandom().Next(allowedCharacters.Length)];
            }
            return new string(password);
        }

        public Random GetStrongRandom()
        {
            byte[] randomBytes = new byte[4];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            int seed = BitConverter.ToInt32(randomBytes, 0);

            return new Random(seed);
        }
    }
}
