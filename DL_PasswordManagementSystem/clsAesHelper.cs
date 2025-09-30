using System;
using System.Security.Cryptography;
using System.Text;

public static class clsAesHelper
{
    private static readonly string key = "1234567890123456";
    private static readonly string iv = "6543210987654321";

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] buffer = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }

    public static string Decrypt(string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] buffer = Convert.FromBase64String(cipherText);

            return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
}
