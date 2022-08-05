using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionProposed.SDSS1
{
    public abstract class KeyGenerationAbstractSDSS1
    {
        protected abstract BigInteger GeneratePrivateKey();
        protected abstract BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberP, BigInteger _PrivateKey);
    }
}
