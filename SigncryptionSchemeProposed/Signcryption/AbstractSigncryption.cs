using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Signcryption
{
    abstract class AbstractSigncryption
    {
        public byte[] ComputeKeyK2(BigInteger _keyKey1)
        {
            return Computation.HashBigIntegerToBytes_SHA1(_keyKey1);
        }

        public byte[] SignMessageWithKey2(string _message, byte[] _keyK2)
        {
            return Computation.KeyedHashStringToBytes_SHA1(_message, _keyK2);
        }

        public byte[] SignMessageWithKey2(string _message, byte[] _keyK2, BigInteger _PublicKeyReceiver)
        {
            return Computation.KeyedHashBytesToBytes_SHA1(
                Computation.KeyedHashStringToBytes_SHA1(_message,
                Computation.HashBigIntegerToBytes_SHA1(_PublicKeyReceiver)), _keyK2);
        }
    }
}
