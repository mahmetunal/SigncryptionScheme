using SigncryptionProposed.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SigncryptionProposed.Signcryption.Participants.Receiver
{
    /// <summary>
    /// This class <c>Unsigncryption</c> inherits from the abstract class <c>AbstractSigncryption</c>. This class 
    /// performs for executing the unsigncryption process. It is called by the reciever only. Hence, it is located within the 
    /// same namespace with the Receiver.
    /// </summary>
    public class Unsigncryption : AbstractSigncryption
    {
        #region Constructor
        public Unsigncryption()
        {

        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// This method unsigncrypt the signcrypted messages and checks whether or not it is valid.
        /// (<paramref name="_signcryptValues"/>,<paramref name="_PrivateKeyOfReceiver"/>,
        ///     <paramref name="globalPrameters"/>,<paramref name="obtainedMessageOut"/>).
        /// </summary>
        /// <returns>
        /// If message come from the valid sender with the valid parameters, it is true. Otherwise, it is false.
        /// </returns>
        /// <remarks>
        /// It unsigncrypts the message by obtaining key1 with the values that sender sent and checks whether or 
        /// not those values and message come from valid user. If the message does not come from the valid user,
        /// it can refuse the message.
        /// </remarks>
        /// <param><c>_signcryptValues</c> is dictionary list that contains values that sender sent.</param>
        /// <param><c>_PrivateKeyOfReceiver</c> is a private key of the receiver.</param>
        /// <param><c>globalPrameters</c> is an instance of <c>GlobalParameters</c> class.</param>
        /// <param><c>obtainedMessageOut</c> is a decrypted message obtained by the unsigncryption process as another return parameter.</param>
        protected bool UnsigncryptTheMessage(Dictionary<string, byte[]> _signcryptValues, BigInteger _PrivateKeyOfReceiver,
            GlobalParameters globalPrameters, out string obtainedMessageOut)
        {
            byte[] valueA1;
            byte[] valueA2;
            byte[] valueC;
            byte[] valueR;
            byte[] valuePrimeR;
            byte[] Key2;
            BigInteger ObtainedKey1;
            string obtainedMessage;

            valueA1 = _signcryptValues[ConstantValuesSigncryption.A1];
            valueA2 = _signcryptValues[ConstantValuesSigncryption.A2];
            valueC = _signcryptValues[ConstantValuesSigncryption.C];
            valueR = _signcryptValues[ConstantValuesSigncryption.R];

            ObtainedKey1 = this.ObtainKeyK1(valueA1, valueA2, _PrivateKeyOfReceiver, globalPrameters);
            Key2 = this.ComputeKeyK2(ObtainedKey1);
            Array.Resize(ref Key2, 32);

            obtainedMessage = this.DecryptMessageWithKey2(valueC, Key2, globalPrameters.RijndaelCryptoSystem.IV);
            obtainedMessageOut = obtainedMessage;
            valuePrimeR = this.SignMessageWithKey2(obtainedMessage, Key2);

            return this.VerifyTheMessage(valueR, valuePrimeR);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method computes key1.
        /// (<paramref name="_ValueA1"/>,<paramref name="_ValueA2"/>,
        ///     <paramref name="_PrivateKey"/>,<paramref name="globalPrameters"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, obtained Key1, which is being used for computing key2.
        /// </returns>
        /// <remarks>
        /// It computes the key by satistfying the following equaiton;
        /// k1 = A2*((A1^x)^{-1})modN
        /// x: Private key of the sender.
        /// </remarks>
        /// <param><c>_ValueA1</c> is A1 that sender computed and sent.</param>
        /// <param><c>_ValueA2</c> is A2 that sender computed and sent.</param>
        /// <param><c>_PrivateKey</c> is a private key of the receiver.</param>
        /// <param><c>globalPrameters</c> is an instance of <c>GlobalParameters</c> class.</param>
        private BigInteger ObtainKeyK1(byte [] _ValueA1, byte[] _ValueA2, BigInteger _PrivateKey, GlobalParameters globalPrameters)
        {
            BigInteger computedValueKeyK1;
            BigInteger valueA1;
            BigInteger valueA2;

            valueA1 = new BigInteger(_ValueA1);
            valueA2 = new BigInteger(_ValueA2);

            BigInteger tempValue1 = BigInteger.ModPow(valueA1, _PrivateKey, globalPrameters.RandomNumberN);

            List<BigInteger> tempList = globalPrameters.ListContainingAllNValues.FindAll(x => BigInteger.Multiply(x, tempValue1) % globalPrameters.RandomNumberN == 1);

            computedValueKeyK1 = BigInteger.Multiply(valueA2, tempList[0]) % globalPrameters.RandomNumberN; 

            return computedValueKeyK1;
        }

        /// <summary>
        /// This method decrypts the message with using obtained key2.
        /// (<paramref name="_cipherText"/>,<paramref name="_keyK2"/>,
        ///     <paramref name="_IV"/>).
        /// </summary>
        /// <returns>
        /// A string, decrypted message with using key2 and IV.
        /// </returns>
        /// <remarks>
        /// It computes the key by satistfying the following equaiton;
        /// k1 = A2*((A1^x)^{-1})modN
        /// x: Private key of the sender.
        /// </remarks>
        /// <param><c>_cipherText</c> is C, which is encrypted message, sender sent.</param>
        /// <param><c>_keyK2</c> is an obtained key2, which is being for decrypting the message.</param>
        /// <param><c>_IV</c> is an initilization vector, which is being used for decrypting the message.</param>
        private string DecryptMessageWithKey2(byte[] _cipherText, byte[] _keyK2, byte[] _IV)
        {
            return Computation.DecryptStringFromBytes_Aes(_cipherText, _keyK2, _IV);
        }

        /// <summary>
        /// This method checks whether or not R and R'(obtained R value) are equal.
        /// (<paramref name="_cipherText"/>,<paramref name="_keyK2"/>,
        ///     <paramref name="_IV"/>).
        /// </summary>
        /// <returns>
        /// If R and R'(obtained R value) are equal, it is true. Otherwise, it is false.
        /// </returns>
        /// <remarks>
        /// It computes the key by satistfying the following equaiton;
        /// k1 = A2*((A1^x)^{-1})modN
        /// x: Private key of the sender.
        /// </remarks>
        /// <param><c>_Rvalue</c> is R value that sender sent.</param>
        /// <param><c>_Rprime</c> is R prime that is obtianed by the receiver.</param>
        private bool VerifyTheMessage(byte[] _Rvalue, byte[] _Rprime)
        {
            return _Rprime.SequenceEqual(_Rvalue);
        }
        #endregion
    }
}
