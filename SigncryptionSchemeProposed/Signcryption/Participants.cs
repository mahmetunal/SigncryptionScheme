using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme
{

    public abstract class Participants
    {
        protected GlobalParameters gb = GlobalParameters.Instance();

        public abstract BigInteger GetPrivateKey();
        public abstract BigInteger GetPublicKey();


    }

    public class Sender: Participants
    {

        public BigInteger SecretKey;
        public BigInteger RandomNumberZ;
        public BigInteger GeneratedNumberBeta;
        private KeyGeneration kg;

        public Sender()
        {
            kg = new KeyGeneration();
            SecretKey = this.GenerateSecretKey1(gb.RandomNumberN);
            RandomNumberZ = this.GenerateRandomNumberZ(gb.RandomNumberN);
            GeneratedNumberBeta = this.GenerateNumberBeta(kg.PrivateKey);
        }
        public override BigInteger GetPrivateKey()
        {
            return kg.PrivateKey;
        }

        public override BigInteger GetPublicKey()
        {
            return kg.PublicKey;
        }

        private BigInteger GenerateSecretKey1(BigInteger _RandomNumberN)
        {
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();
            return RBI.RandomBigInteger(BigInteger.Zero, _RandomNumberN - 1);
        }

        private BigInteger GenerateRandomNumberZ(BigInteger _RandomNumberN)
        {
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();
            return RBI.RandomBigInteger(BigInteger.Zero, _RandomNumberN - 1);
        }

        private BigInteger GenerateNumberBeta(BigInteger _PrivateKey)
        {
            BigInteger RandomNumberZ = GenerateRandomNumberZ(gb.RandomNumberN);
            return BigInteger.ModPow(RandomNumberZ,_PrivateKey,gb.RandomNumberN);
        }
    }

    public class Receiver : Participants
    {
        private KeyGeneration kg;
        public Receiver()
        {
            kg = new KeyGeneration();
        }
        
        public override BigInteger GetPrivateKey()
        {
            return kg.PrivateKey;
        }

        public override BigInteger GetPublicKey()
        {
            return kg.PublicKey;
        }
    }
}
