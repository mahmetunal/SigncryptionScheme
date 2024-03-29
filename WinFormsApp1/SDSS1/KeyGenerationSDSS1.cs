﻿using SigncryptionProposed.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionProposed.SDSS1
{
    public class KeyGenerationSDSS1 : KeyGenerationAbstractSDSS1
    {
        public BigInteger PublicKey;

        /* Normally, it is supposed to be secret*/
        public BigInteger PrivateKey;


        GlobalParametersSDSS1 globalParametersSdss1 = GlobalParametersSDSS1.Instance();

        public KeyGenerationSDSS1()
        {
            this.KeyGenerationInit();
        }

        private void KeyGenerationInit()
        {
            this.PrivateKey = GeneratePrivateKey();
            this.PublicKey = GeneratePublicKey(globalParametersSdss1.RandomNumberG, globalParametersSdss1.RandomNumberP, this.PrivateKey);
        }

        public void GenerateNewKeyes()
        {
            globalParametersSdss1.GenerateNewParameters();
            this.KeyGenerationInit();
        }

        protected override BigInteger GeneratePrivateKey()
        {
            return globalParametersSdss1.SelectingRandomListValue(globalParametersSdss1.ListContainingAllQValues);

        }

        protected override BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberP, BigInteger _PrivateKey)
        {
            return BigInteger.ModPow(_RandomNumberG, _PrivateKey, _RandomNumberP);
        }
    }
}
