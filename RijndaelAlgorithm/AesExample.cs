using System;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace RijndaelAlgorithm
{
    public class AesExample
    {
        public static void Main()
        {
            //string original = "Here is some data to encrypt!";
            string original = System.IO.File.ReadAllText("../../../../Datasets/dataset32768.txt");

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using Aes myAes = Aes.Create();
            using Aes secondAes = Aes.Create();


            // Encrypt the string to an array of bytes.
            byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
            byte[] hashed = HashStringToBytes_SHA1(original);
            Console.WriteLine("Key size {0}", myAes.KeySize);

            // Decrypt the bytes to a string.
            string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
            byte[] hashedRoundTrip = HashStringToBytes_SHA1(roundtrip);

            //Display the original data and the decrypted data.
            //Console.WriteLine("Original:   {0}", original);
            //Console.WriteLine("Encrypted:   {0}", System.Text.Encoding.Default.GetString(encrypted));
            //Console.WriteLine("Round Trip: {0}", roundtrip);
            Console.WriteLine("Are they equal for encryption: {0}", roundtrip == original);
            Console.WriteLine("Are they equal for hashing: {0}", System.Text.Encoding.Default.GetString(hashed) == System.Text.Encoding.Default.GetString(hashedRoundTrip));

            //Making comparison in byte array level
            Console.WriteLine("Are they equal for hashing: {0}", hashed.AsSpan<byte>().SequenceEqual(hashedRoundTrip));
            Console.WriteLine("Hashed version: {0}", System.Text.Encoding.Default.GetString(hashed));
        }

        #region EncryptionDecryptionRijndael
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new MemoryStream();
                using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException(nameof(Key));
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException(nameof(IV));

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new MemoryStream(cipherText);
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }

        #endregion EncryptionDecryptionRijndael

        #region SHA1ComputeHash

        static byte[] HashStringToBytes_SHA1(string plainText)
        {
            // Check argument.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            
            byte[] hashed;
            byte[] sourceBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            // Create a SHA1 object
            using SHA1 sha1Hash = SHA1.Create();
            hashed = sha1Hash.ComputeHash(sourceBytes); 
            

            // Return the hashed bytes from the memory stream.
            return hashed;
        }

        static byte[] HashBigIntegerToBytes_SHA1(BigInteger _input)
        {
            // Check argument.
            if (_input.IsZero)
                throw new ArgumentNullException(nameof(_input));

            byte[] hashed;
            byte[] sourceBytes = _input.ToByteArray();

            // Create a SHA1 object
            using SHA1 sha1Hash = SHA1.Create();
            hashed = sha1Hash.ComputeHash(sourceBytes);

            // Return the hashed bytes from the memory stream.
            return hashed;
        }

        #endregion SHA1ComputeHash
    }

}
