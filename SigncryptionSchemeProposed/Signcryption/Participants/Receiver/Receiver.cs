using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionScheme.Signcryption.Participants.Receiver
{
    public class Receiver : Unsigncryption
    {
        private KeyGeneration kg;
        public Receiver()
        {
            kg = new KeyGeneration();
        }

        public bool MessageUnsigncryption(Dictionary<string, byte[]> _signcryptValues)
        {
            return this.UnsigncryptTheMessage(_signcryptValues, GetPrivateKey());
        }

        public BigInteger GetPublicKey()
        {
            return kg.PublicKey;
        }
        private BigInteger GetPrivateKey()
        {
            return kg.PrivateKey;
        }
    }
}
