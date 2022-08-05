using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.SDSS2
{
    public abstract class KeyGenerationAbstractSDSS2
    {
        protected abstract BigInteger GeneratePrivateKey();
        protected abstract BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberP, BigInteger _PrivateKey);
    }
}
