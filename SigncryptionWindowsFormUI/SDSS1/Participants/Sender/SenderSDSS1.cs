using SigncryptionProposed.Computations;
using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionProposed.SDSS1.Participants.Sender
{
    public class SenderSDSS1 : SigncryptionSDSS1
    {
        GlobalParametersSDSS1 gb = GlobalParametersSDSS1.Instance();

        private BigInteger RandomNumberX;
        private KeyGenerationSDSS1 keyGenerationSdss1;


        public SenderSDSS1()
        {
            keyGenerationSdss1 = new KeyGenerationSDSS1();
            RandomNumberX = this.GenerateRandomNumberX();
        }

        public Dictionary<string, byte[]> MessageSigncryption(string message, BigInteger _PublicKeyReceiver)
        {
            bool isErrorOccured = false;
            Dictionary<string, byte[]> signcryptValues = new Dictionary<string, byte[]>();

            do
            {
                if (isErrorOccured)
                    RandomNumberX = this.GenerateRandomNumberX();
                signcryptValues = this.SigncryptTheMessage(message, _PublicKeyReceiver, this.RandomNumberX, GetPrivateKey(), out isErrorOccured);
            } while (isErrorOccured);

            return signcryptValues;
        }

        public BigInteger GetPublicKey()
        {
            return keyGenerationSdss1.PublicKey;
        }
        private BigInteger GetPrivateKey()
        {
            return keyGenerationSdss1.PrivateKey;
        }

        private BigInteger GenerateRandomNumberX()
        {
            return gb.SelectingRandomListValue(gb.RelativePrimesOfQ);
        }
        
    }
}
