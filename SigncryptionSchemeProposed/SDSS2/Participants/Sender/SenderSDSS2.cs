using SigncryptionScheme.Computations;
using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionScheme.SDSS2.Participants.Sender
{
    public class SenderSDSS2 : SigncryptionSDSS2
    {
        GlobalParametersSDSS2 gb = GlobalParametersSDSS2.Instance();

        private BigInteger RandomNumberX;
        private KeyGenerationSDSS2 kg;


        public SenderSDSS2()
        {
            kg = new KeyGenerationSDSS2();
            RandomNumberX = this.GenerateRandomNumberX();
        }

        public Dictionary<string, byte[]> MessageSigncryption(string message, BigInteger _PublicKeyReceiver)
        {
            bool isErrorOccured = false;
            Dictionary<string, byte[]> signcryptValues = new Dictionary<string, byte[]>();
            do
            {
                if(isErrorOccured)
                    RandomNumberX = this.GenerateRandomNumberX();
                
            signcryptValues = this.SigncryptTheMessage(message, _PublicKeyReceiver, this.RandomNumberX, GetPrivateKey(), out isErrorOccured);
            } while (isErrorOccured);

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
