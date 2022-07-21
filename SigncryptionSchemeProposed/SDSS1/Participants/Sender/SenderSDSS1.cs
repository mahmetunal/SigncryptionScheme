﻿using SigncryptionScheme.Computations;
using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionScheme.SDSS1.Participants.Sender
{
    public class SenderSDSS1 : SigncryptionSDSS1
    {
        GlobalParametersSDSS1 gb = GlobalParametersSDSS1.Instance();

        private BigInteger RandomNumberX;
        private KeyGenerationSDSS1 kg;


        public SenderSDSS1()
        {
            kg = new KeyGenerationSDSS1();
            RandomNumberX = this.GenerateRandomNumberX();
        }

        public Dictionary<string, byte[]> MessageSigncryption(string message, BigInteger _PublicKeyReceiver)
        {
            bool isErrorOccured = false;
            Dictionary<string, byte[]> signcryptValues = new Dictionary<string, byte[]>();

            /*do
            {
                if (isErrorOccured)
                    RandomNumberX = this.GenerateRandomNumberX();
                

            } while (isErrorOccured);*/

            signcryptValues = this.SigncryptTheMessage(message, _PublicKeyReceiver, this.RandomNumberX, GetPrivateKey(), out isErrorOccured);
            return signcryptValues;
        }

        public BigInteger GetPublicKey()
        {
            return kg.PublicKey;
        }
        private BigInteger GetPrivateKey()
        {
            return kg.PrivateKey;
        }

        private BigInteger GenerateRandomNumberX()
        {
            return gb.SelectingRandomListValue(gb.RelativePrimesOfQ);
        }
        
    }
}