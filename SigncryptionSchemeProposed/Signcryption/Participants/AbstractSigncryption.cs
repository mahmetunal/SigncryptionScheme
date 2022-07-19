using System.Numerics;

namespace SigncryptionScheme.Signcryption
{
    public abstract class AbstractSigncryption
    {
        protected byte[] ComputeKeyK2(BigInteger _keyKey1)
        {
            return Computation.HashBigIntegerToBytes_SHA1(_keyKey1);
        }

        protected byte[] SignMessageWithKey2(string _message, byte[] _keyK2)
        {
            return Computation.KeyedHashStringToBytes_SHA1(_message, _keyK2);
        }

        protected byte[] SignMessageWithKey2(string _message, byte[] _keyK2, BigInteger _PublicKeyReceiver)
        {
            return Computation.KeyedHashBytesToBytes_SHA1(
                Computation.KeyedHashStringToBytes_SHA1(_message,
                Computation.HashBigIntegerToBytes_SHA1(_PublicKeyReceiver)), _keyK2);
        }
    }
}
