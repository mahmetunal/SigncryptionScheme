﻿using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme
{
    public class KeyGeneration : KeyGenerationAbstract
    {
        public BigInteger PublicKey;

        /* Normally, it is supposed to be secret*/
        public BigInteger PrivateKey;


        GlobalParameters gb = GlobalParameters.Instance();

        public KeyGeneration()
        {
            this.KeyGenerationInit();
        }

        public void KeyGenerationInit()
        {
            this.PrivateKey = GeneratePrivateKey(gb.RandomNumberN, gb.RandomNumberG);
            this.PublicKey = GeneratePublicKey(gb.RandomNumberG, gb.RandomNumberN, this.PrivateKey);
        }

        public void GenerateNewKeyes()
        {
            gb.GenerateNewParameters();
            this.KeyGenerationInit();
        }

        protected override BigInteger GeneratePrivateKey(BigInteger _RandomNumberN, BigInteger _RandomNumberG)
        {
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();
            return RBI.RandomBigInteger(BigInteger.Zero, _RandomNumberN - 1); ;
        }

        protected override BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberN, BigInteger _PrivateKey)
        {
            return BigInteger.ModPow(_RandomNumberG, _PrivateKey, _RandomNumberN);
        }
    }
}