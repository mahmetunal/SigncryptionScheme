using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.SDSS2
{
    public class KeyGenerationSDSS2 : KeyGenerationAbstractSDSS2
    {
        public BigInteger PublicKey;

        /* Normally, it is supposed to be secret*/
        public BigInteger PrivateKey;


        GlobalParametersSDSS2 gb = GlobalParametersSDSS2.Instance();

        public KeyGenerationSDSS2()
        {
            this.KeyGenerationInit();
        }

        private void KeyGenerationInit()
        {
            this.PrivateKey = GeneratePrivateKey();
            this.PublicKey = GeneratePublicKey(gb.RandomNumberG, gb.RandomNumberP, this.PrivateKey);
        }

        public void GenerateNewKeyes()
        {
            gb.GenerateNewParameters();
            this.KeyGenerationInit();
        }

        protected override BigInteger GeneratePrivateKey()
        {
            return gb.SelectingRandomListValue(gb.RelativePrimesOfQ);

        }

        protected override BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberP, BigInteger _PrivateKey)
        {
            return BigInteger.ModPow(_RandomNumberG, _PrivateKey, _RandomNumberP);
        }
    }
}
