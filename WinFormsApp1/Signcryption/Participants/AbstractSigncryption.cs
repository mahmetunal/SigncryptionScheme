using System.Numerics;

namespace SigncryptionProposed.Signcryption
{
    /// <summary>
    /// This abstract class <c>AbstractSigncryption</c> contains the common methods for being used in both
    /// signcryption and unsigncryption processes.
    /// </summary>
    public class AbstractSigncryption
    {
        #region Protected Methods
        /// <summary>
        /// This method computes the key2 in both signcryption and unsigncryption processes..
        /// (<paramref name="_keyKey1"/>).
        /// </summary>
        /// <returns>
        /// A byte array that contains hashed key1, randomly chosen by the sender.
        /// </returns>
        /// <remarks>
        /// Key2 is a hashed of key1, in this case hashed of _keyKey1
        /// </remarks>
        /// <param><c>_keyKey1</c> is a randomly chosen secret number by the sender.</param>
        protected byte[] ComputeKeyK2(BigInteger _keyKey1)
        {
            return Computation.HashBigIntegerToBytes_SHA1(_keyKey1);
        }

        /// <summary>
        /// This method hashes the message with the key2.
        /// (<paramref name="_message"/>,<paramref name="_keyK2"/>).
        /// </summary>
        /// <returns>
        /// A byte array, keyed hashed of message with key2.
        /// </returns>
        /// <remarks>
        /// This method is being used for computing R value in the signcryption and
        /// r' value in the unsigncryption process. It hashes or signs the message with using key2
        /// </remarks>
        /// <param><c>_message</c> is a message to be signed.</param>
        /// <param><c>_keyK2</c> is a key performing the message authentication code, which is eventually being used for hashing
        /// the message</param>
        protected byte[] SignMessageWithKey2(string _message, byte[] _keyK2)
        {
            return Computation.KeyedHashStringToBytes_SHA1(_message, _keyK2);
        }

        /// <summary>
        /// This method hashes the message and the public key of the receiver with the key2.
        /// (<paramref name="_message"/>,<paramref name="_keyK2"/>,<paramref name="_PublicKeyReceiver"/>).
        /// </summary>
        /// <returns>
        /// A byte array, keyed hashed of message and the public key of the receiver with key2.
        /// </returns>
        /// <remarks>
        /// This method is being used for computing R value in the signcryption and
        /// R' value in the unsigncryption process. It hashes or signs the message and the public 
        /// key of the receiver with using key2
        /// </remarks>
        /// <param><c>_message</c> is a message to be signed.</param>
        /// <param><c>_keyK2</c> is a key performing the message authentication code, which is eventually being used for hashing
        /// the message</param>
        /// <param><c>_PublicKeyReceiver</c> is a public key of the receiver to be hashed.</param>
        protected byte[] SignMessageWithKey2(string _message, byte[] _keyK2, BigInteger _PublicKeyReceiver)
        {
            return Computation.KeyedHashBytesToBytes_SHA1(
                Computation.KeyedHashStringToBytes_SHA1(_message,
                Computation.HashBigIntegerToBytes_SHA1(_PublicKeyReceiver)), _keyK2);
        }
        #endregion
    }
}
