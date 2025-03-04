using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Codebase.Infrastructure.Utils
{
    public static class AesKeyGenerator
    {
        public static void GenerateAesKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[32];
                var iv = new byte[16];

                rng.GetBytes(key);
                rng.GetBytes(iv);

                Debug.Log("Key: " + Convert.ToBase64String(key));
                Debug.Log("IV:  " + Convert.ToBase64String(iv));
            }
        }
    }
}