using System;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace SigncryptionScheme
{
    public class Computation
    {

        #region EncryptionDecryptionRijndael
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
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
                aesAlg.Padding = PaddingMode.Zeros;
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

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
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
                aesAlg.Padding = PaddingMode.Zeros;
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

        public static byte[] DecryptByteArrayFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
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
            byte[] decryptedArray;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new MemoryStream(cipherText);
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);

                csDecrypt.Write(cipherText, 0, cipherText.Length);
                csDecrypt.FlushFinalBlock();

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                decryptedArray = msDecrypt.ToArray();
            }

            return decryptedArray;
        }

        #endregion EncryptionDecryptionRijndael

        #region SHA1ComputeHash

        public static byte[] HashStringToBytes_SHA1(string plainText)
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

        public static byte[] HashBigIntegerToBytes_SHA1(BigInteger _input)
        {
            // Check argument.
            if (_input.IsZero)
                //_input = BigInteger.One;
                throw new ArgumentNullException(nameof(_input));

            byte[] hashed;
            byte[] sourceBytes = _input.ToByteArray();

            // Create a SHA1 object
            using SHA1 sha1Hash = SHA1.Create();
            hashed = sha1Hash.ComputeHash(sourceBytes);

            // Return the hashed bytes from the memory stream.
            return hashed;
        }

        public static byte[] HashDoubleToBytes_SHA1(double _input)
        {
            // Check argument.
            if (_input.Equals(0))
                throw new ArgumentNullException(nameof(_input));

            byte[] hashed;
            byte[] sourceBytes = BitConverter.GetBytes(_input);

            // Create a SHA1 object
            using SHA1 sha1Hash = SHA1.Create();
            hashed = sha1Hash.ComputeHash(sourceBytes);

            // Return the hashed bytes from the memory stream.
            return hashed;
        }

        public static byte[] KeyedHashStringToBytes_SHA1(string _message, byte[] _secretKey)
        {
            // Check argument.
            if (_message == null || _secretKey.Length == 0)
                throw new ArgumentNullException(nameof(_message));

            byte[] sourceBytes = System.Text.Encoding.UTF8.GetBytes(_message);

            // Create a SHA1 object
            using HMACSHA1 keyedHashSha1 = new HMACSHA1(key: _secretKey);
            return keyedHashSha1.ComputeHash(sourceBytes);

        }

        public static byte[] KeyedHashBytesToBytes_SHA1(byte[] _message, byte[] _secretKey)
        {
            // Check argument.
            if (_message == null || _secretKey.Length == 0)
                throw new ArgumentNullException(nameof(_message));


            // Create a SHA1 object
            using HMACSHA1 keyedHashSha1 = new HMACSHA1(key: _secretKey);
            return keyedHashSha1.ComputeHash(_message);

        }

        public static byte[] HashBigIntegerToBytes_SHA1Managed(BigInteger _input)
        {
            // Check argument.
            if (_input.IsZero)
                throw new ArgumentNullException(nameof(_input));

            byte[] hashed;
            byte[] sourceBytes = _input.ToByteArray();

            // Create a SHA1 object
            using SHA1Managed sha1Hash = new SHA1Managed();
            hashed = sha1Hash.ComputeHash(sourceBytes);

            // Return the hashed bytes from the memory stream.
            return hashed;
        }
        #endregion SHA1ComputeHash
    }
}
