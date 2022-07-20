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

        public bool MessageUnsigncryption(Dictionary<string, byte[]> _signcryptValues, out string _message_)
        {
            bool isMessageVerified = this.UnsigncryptTheMessage(_signcryptValues, GetPrivateKey(), out string _message);

            if (isMessageVerified)
                _message_ = _message;
            else
                _message_ = "Message could not verified.";

            return isMessageVerified;
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
