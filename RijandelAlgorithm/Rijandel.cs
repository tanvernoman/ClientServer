using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace RijandelAlgorithm
{
    public class Rijandel
    {
      public static MemoryStream memoryStream;
     public static  CryptoStream cryptoStream;

        public static string Encrypt(string plainText, string passPhrase, string saltValue, string algo, int piteration, string initVector, int keySize)
        {
            byte[] inirVecByte = Encoding.ASCII.GetBytes(initVector);
            byte[] salt = Encoding.ASCII.GetBytes(saltValue);

            byte[] bytePlainText = Encoding.UTF8.GetBytes(plainText);


            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                salt,
                algo,
                piteration
            );

            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged key = new RijndaelManaged();


            key.Mode = CipherMode.CBC;


            ICryptoTransform encryptor = key.CreateEncryptor
            (
                keyBytes,
                inirVecByte
            );

            // Define memory stream which will be used to hold encrypted data.
           // MemoryStream
                memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
           // CryptoStream
                cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );

            // Start encrypting.
            cryptoStream.Write(bytePlainText, 0, bytePlainText.Length);

            // Finish encrypting.
             cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipher = memoryStream.ToArray();

            // Close both streams.
           // closeStream(memoryStream, cryptoStream);
            memoryStream.Close();
            cryptoStream.Close();
            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipher);


            return cipherText;
        }


        public static string Decrypt(string cipherText, string passPhrase, string saltValue, string algo, int piteration, string initVector, int keySize)
        {

            byte[] inirVecByte = Encoding.ASCII.GetBytes(initVector);
            byte[] salt = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            byte[] cipher = Convert.FromBase64String(cipherText);
            //byte[] cipher = Encoding.ASCII.GetBytes(cipherText);
            //byte[]
            // byte[] cipher = Encoding.ASCII.GetBytes(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                salt,
                algo,
                piteration
            );

            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged key = new RijndaelManaged();


            key.Mode = CipherMode.CBC;


            ICryptoTransform decryptor = key.CreateDecryptor
            (
                keyBytes,
                inirVecByte
            );

            // Define memory stream which will be used to hold encrypted data.
           // MemoryStream
                memoryStream = new MemoryStream(cipher);

            // Define cryptographic stream (always use Read mode for encryption).
           // CryptoStream 
                cryptoStream = new CryptoStream
            (
                memoryStream,
                decryptor,
                CryptoStreamMode.Read
            );


            byte[] bytePlainText = new byte[cipher.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read
            (
                bytePlainText,
                0,
                bytePlainText.Length
            );

            // Close both streams.
           // closeStream(memoryStream, cryptoStream);
            memoryStream.Close();
            cryptoStream.Close();

            string plainText = Encoding.UTF8.GetString
            (
                bytePlainText,
                0,
                decryptedByteCount
            );

            // Return decrypted string.   
            return plainText;
        }

        public static void closeStream(MemoryStream memoryStream, CryptoStream cryptoStream)
        {
            memoryStream.Close();
            cryptoStream.Close();
        }
    }

}