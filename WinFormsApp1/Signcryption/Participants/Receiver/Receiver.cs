﻿using System.Collections.Generic;
using System.Numerics;

namespace SigncryptionProposed.Signcryption.Participants.Receiver
{

    /// <summary>
    /// This class <c>Receiver</c> inherits from the <c>Unsigncryption</c> class for executing methods defined in the <c>Unsigncryption</c> class.
    /// This class generates the Receiver and it can perform signcryption process.
    /// </summary>
    public class Receiver : Unsigncryption
    {
        #region Properties
        /// <value>Property <c>keyGeneration</c> represents the instance of the <c>GlobalParameters</c> class.</value>
        private KeyGeneration keyGeneration;
        #endregion

        #region Constructor
        /// <summary>
        /// This constructor initializes the necessary property for getting both public and private key.
        /// </summary>
        public Receiver()
        {
            keyGeneration = new KeyGeneration();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method unsigncrypt the signcrypted messages and checks whether or not it is valid.
        /// (<paramref name="_signcryptValues"/>,<paramref name="_message_"/>).
        /// </summary>
        /// <returns>
        /// If message come from the valid sender with the valid parameters, it is true. Otherwise, it is false.
        /// </returns>
        /// <remarks>
        /// It unsigncrypts the message and checks whether or not those values and message come from valid user. 
        /// If the message does not come from the valid user, it can refuse the message.
        /// </remarks>
        /// <param><c>_signcryptValues</c> is dictionary list that contains values that sender sent.</param>
        /// <param><c>_message</c> is a decrypted message obtained by the unsigncryption process as another return parameter.</param>
        public bool MessageUnsigncryption(Dictionary<string, byte[]> _signcryptValues, out string _message_)
        {
            bool isMessageVerified = this.UnsigncryptTheMessage(_signcryptValues, GetPrivateKey(), keyGeneration.globalParameters, out string _message);

            if (isMessageVerified)
                _message_ = _message;
            else
                _message_ = "Message could not verified.";

            return isMessageVerified;
        }

        /// <summary>
        /// This method generates the public key of the receiver.
        /// </summary>
        /// <returns>
        /// A Big Integer, public key of the receiver.
        /// </returns>
        /// /// <remarks>
        /// Public key is not generated by the receiver. the instance of <c>KeyGeneration</c> class 
        /// is generated them once it is initialized.
        /// </remarks>
        public BigInteger GetPublicKey()
        {
            return keyGeneration.PublicKey;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method generates the private key of the receiver.
        /// </summary>
        /// <returns>
        /// A Big Integer, private key of the receiver.
        /// </returns>
        /// <remarks>
        /// Private key is not generated by the receiver. the instance of <c>KeyGeneration</c> class 
        /// is generated them once it is initialized.
        /// </remarks>
        private BigInteger GetPrivateKey()
        {
            return keyGeneration.PrivateKey;
        }
        #endregion
    }
}