using System.Numerics;

namespace SigncryptionScheme.SDSS2.Participants
{
    public abstract class AbstractSigncryptionSDSS2
    {
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

        protected BigInteger ComputeR(byte[] _computedValueR, BigInteger _RandomNumberQ)
        {
            BigInteger valueR = new BigInteger(value: _computedValueR,
                isUnsigned: true,
                isBigEndian: true);

            return valueR % (_RandomNumberQ);
        }
    }
}
