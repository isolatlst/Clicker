using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine.Device;

namespace Codebase.Infrastructure.Utils
{
    public static class AesUtility
    {
        private static readonly byte[] Key = Convert.FromBase64String("Давайте, кому другому расскажите про ключи на гите");

        public static string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
                using (var ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);

                    using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cryptoStream))
                    {
                        writer.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(cipherText);

                using (var aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var ms = new MemoryStream(encryptedData))
                    {
                        var iv = new byte[16];
                        ms.Read(iv, 0, iv.Length);

                        using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
                        using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        using (var reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                // Application.Quit(); // TODO лучше бы сделать что-то покеративнее)))))))
                return null; 
            }
        }
    }
}