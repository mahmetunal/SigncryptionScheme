using System;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace SigncryptionProposed
{
    /// <summary>
    /// This class <c>Computation</c> is being used for encrypting, decrypting with 
    /// Rijndael Algorithm, which is also known as Advanced Encryption Standard,
    /// and hashing with SHA1 hash algorithm. This class is publicly accessible.
    /// </summary>
    public class Computation
    {

        #region EncryptionDecryptionRijndael
        /// <summary>
        /// This method encrypts messages with the specified Key and Initilization
        /// Vector using AES (Rijndael Algorithm) and returns encrypted value as a byte array
        /// (<paramref name="plainText"/>,<paramref name="Key"/>,<paramref name="IV"/>).
        /// </summary>
        /// <returns>
        /// A byte array storing the encrypted text.
        /// </returns>
        /// <param><c>plainText</c> is a message that wants to encrypt.</param>
        /// <param><c>Key</c> is a key used in encryption algorithm to encrypt the message.
        /// It should be 256 bit length or more.</param>
        /// <param><c>IV</c> is an initilizatin vector, which is being used in the 
        /// first round of the Rijndael Algorithm. It should be 256 bit length or more.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the plainText, Key and IV are null or their length are 
        /// less than or equal to zero.
        /// </exception>
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
                aesAlg.Padding = PaddingMode.PKCS7;
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

        /// <summary>
        /// This method decrypts the encrypted message, which is stored as a byte array
        /// with the specified Key and Initilization Vector using AES (Rijndael Algorithm) 
        /// and returns decrypted message as a string value
        /// (<paramref name="cipherText"/>,<paramref name="Key"/>,<paramref name="IV"/>).
        /// </summary>
        /// <returns>
        /// A string value obtained by decrypting the encrypted message.
        /// </returns>
        /// <param><c>cipherText</c> is the encrypted byte array to be decrypted.</param>
        /// <param><c>Key</c> is a key used in decryption algorithm to encrypt the decrypt.
        /// It should be 256 bit length or more and the same key as the one used in 
        /// Encryption.</param>
        /// <param><c>IV</c> is an initilizatin vector, which is being used in the 
        /// first round of the Rijndael Algorithm. It should be 256 bit length or more
        /// the same key as the one used in Encryption.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the ciphertext, Key and IV are null or their length are 
        /// less than or equal to zero.
        /// </exception>
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
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Padding = PaddingMode.PKCS7;
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
            }
            catch 
            {
                plaintext = "";
            }
            

            return plaintext;
        }

        #endregion EncryptionDecryptionRijndael

        #region SHA1ComputeHash
        /// <summary>
        /// This method hashes the given BigInteger value by using SHA1 
        /// Hash Algorithm.
        /// (<paramref name="_input"/>).
        /// </summary>
        /// <returns>
        /// A byte array storing the hashed big integer value.
        /// </returns>
        /// <param><c>_input</c> is a big integer to be hashed</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the given input value is 0.
        /// </exception>
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

        /// <summary>
        /// This method hashes the given string message by using SHA1
        /// Hash Algorithm with using secret key. This method is also known as Keyed
        /// Hash Algorithm, which performs message authentication code with the secret key given.
        /// (<paramref name="_message"/>,<paramref name="_secretKey"/>).
        /// </summary>
        /// <returns>
        /// A byte array that keyed hashed of the message with using secret key.
        /// </returns>
        /// <param><c>_message</c> is a message to be keyed hashed.</param>
        /// <param><c>_secretKey</c> is a secret key performing the message
        /// authentication code, which is eventually being used for hashing
        /// the message</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the message is null or the length of the secret key is 0.
        /// </exception>
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

        /// <summary>
        /// This method hashes the given byte array message value by using SHA1
        /// Hash Algorithm with using secret key. This methos is also known as Keyed
        /// Hash Algorithm, which performs message authentication code with the secret key given.
        /// (<paramref name="_message"/>,<paramref name="_secretKey"/>).
        /// </summary>
        /// <returns>
        /// A byte array that keyed hashed of the message, which is byte array, with using secret key.
        /// </returns>
        /// <param><c>_message</c> is a message to be keyed hashed.</param>
        /// <param><c>_secretKey</c> is a secret key performing the message
        /// authentication code, which is eventually being used for hashing
        /// the message</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the message is null or the length of the secret key is 0.
        /// </exception>
        public static byte[] KeyedHashBytesToBytes_SHA1(byte[] _message, byte[] _secretKey)
        {
            // Check argument.
            if (_message == null || _secretKey.Length == 0)
                throw new ArgumentNullException(nameof(_message));


            // Create a SHA1 object
            using HMACSHA1 keyedHashSha1 = new HMACSHA1(key: _secretKey);
            return keyedHashSha1.ComputeHash(_message);

        }

        #endregion SHA1ComputeHash

        /// <summary>
        /// This method give the timestamp value of the time when it is called.
        /// </summary>
        /// <returns>
        /// A long timestamp value.
        /// </returns>
        public static long GetTimeStamp()
        {
            return DateTime.Now.Ticks;
        }
    }
}
