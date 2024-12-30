using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MudahMed.Common.Encrypt
{
    public class HashingAES256d
    {
        // Key and IV should be securely generated and managed in a real-world application
        public static string key = "myMedsecretkey12"; // 16 characters for 128-bit key
        public static string iv = "myMedsecretiv123";   // 16 characters for 128-bit IV

        public static byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        public static byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

        // Generates a SHA-256 hash of the input string
        public static string GenerateSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Encrypts a string using AES encryption
        public static string EncryptStringToBytes_Aes(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        // Decrypts a string using AES decryption
        public static string DecryptStringFromBytes_Aes(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
