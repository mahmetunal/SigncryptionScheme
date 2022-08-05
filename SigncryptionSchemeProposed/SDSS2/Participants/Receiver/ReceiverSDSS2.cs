using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionScheme.SDSS2.Participants.Receiver
{
    public class ReceiverSDSS2 : UnsigncryptionSDSS2
    {
        private KeyGenerationSDSS2 kg;
        public ReceiverSDSS2()
        {
            kg = new KeyGenerationSDSS2();
        }

        public bool MessageUnsigncryption(Dictionary<string, byte[]> _signcryptValues, BigInteger _PublicKeyOfSender, out string _message_)
        {
            bool isMessageVerified  = this.UnsigncryptTheMessage(_signcryptValues, GetPrivateKey(), _PublicKeyOfSender, out string _message);

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
