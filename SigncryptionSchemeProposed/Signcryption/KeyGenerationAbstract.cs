using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme
{
    public abstract class KeyGenerationAbstract
    {
        protected abstract BigInteger GeneratePrivateKey(BigInteger _RandomNumberN, BigInteger _RandomNumberG);
        protected abstract BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberN, BigInteger _PrivateKey);
    }
}
