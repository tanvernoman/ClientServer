using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    public class RijandleManagedEnDe
    {
        RijndaelManaged myRijndael;




        public RijandleManagedEnDe()
        {
            myRijndael = new RijndaelManaged();

            myRijndael.Key = new byte[32] { 118, 123, 23, 17, 161, 152, 35, 68, 126, 213, 16, 115, 68, 217, 58, 108, 56, 218, 5, 78, 28, 128, 113, 208, 61, 56, 10, 87, 187, 162, 233, 38 }; ;
            myRijndael.IV = new byte[16] { 33, 241, 14, 16, 103, 18, 14, 248, 4, 54, 18, 5, 60, 76, 16, 191 };
            //myRijndael.Padding = PaddingMode.None;
        }




        public byte[] EncryptStringToBytes(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            //if (Key == null || Key.Length <= 0)
            //    throw new ArgumentNullException("Key");
            //if (IV == null || IV.Length <= 0)
            //    throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.


            // myRijndael.Padding = PaddingMode.Zeros;
            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV);


            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                       // csEncrypt.FlushFinalBlock();

                    }
                    encrypted = msEncrypt.ToArray();

                }

            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public string DecryptStringFromBytes(byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");


            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            //  myRijndael.Padding = PaddingMode.Zeros;


            
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();


                        }
                    }


                }
            
           
         
            return plaintext;

        }
    }
}