using SigncryptionScheme.Computations;
using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionScheme.Signcryption.Participants.Sender
{
    public class Sender : Signcryption
    {
        GlobalParameters gb = GlobalParameters.Instance();

        private BigInteger SecretKey;
        private BigInteger RandomNumberZ;
        private BigInteger GeneratedNumberBeta;
        private KeyGeneration kg;


        public Sender()
        {
            kg = new KeyGeneration();
            SecretKey = this.GenerateSecretKey1(gb.RandomNumberN);
            RandomNumberZ = this.GenerateRandomNumberZ(gb.RandomNumberN);
            GeneratedNumberBeta = this.GenerateNumberBeta(GetPrivateKey());
        }

        public Dictionary<string, byte[]> MessageSigncryption(string message, BigInteger _PublicKeyReceiver)
        {
            return this.SigncryptTheMessage(message, _PublicKeyReceiver, this.GeneratedNumberBeta, this.SecretKey);
        }

        public BigInteger GetPublicKey()
        {
            return kg.PublicKey;
        }
        private BigInteger GetPrivateKey()
        {
            return kg.PrivateKey;
        }

        private BigInteger GenerateSecretKey1(BigInteger _RandomNumberN)
        {

            //return BigInteger.One;
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
            return BigInteger.ModPow(RandomNumberZ, _PrivateKey, gb.RandomNumberN);
        }

        
    }
}
