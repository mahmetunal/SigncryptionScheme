using SigncryptionProposed.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionProposed.Signcryption.Participants.Sender
{
    /// <summary>
    /// This class <c>Signcryption</c> inherits from the abstract class <c>AbstractSigncryption</c>. This class 
    /// performs for executing the signcryption process. It is called by the sender only. Hence, it is located within the 
    /// same namespace with the Sender.
    /// </summary>
    public class Signcryption : AbstractSigncryption
    {
        #region Constructor
        public Signcryption()
        {

        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// This method computes the values that are generated after the signcrryption process.
        /// (<paramref name="message"/>,<paramref name="_PublicKeyReceiver"/>,<paramref name="_Beta"/>,
        ///     <paramref name="_KeyK1"/>,<paramref name="globalParameters"/>).
        /// </summary>
        /// <returns>
        /// A dictionary with byte arrays containing signcryption output values, namely; A1, A2, C, and R.
        /// </returns>
        /// <remarks>
        /// It computes all the output values of the signcryption process and stores them in the dictionary list.
        /// Dictionary keys defined in publicly accessible <c>ConstantValuesSigncryption</c> class.
        /// </remarks>
        /// <param><c>message</c> is a message to be signcrypted.</param>
        /// <param><c>_PublicKeyReceiver</c> is a public key of the receiver.</param>
        /// <param><c>_Beta</c> is a computed secret value by the sender.</param>
        /// <param><c>_KeyK1</c> is a randomly chosen secret key by the sender.</param>
        /// <param><c>globalParameters</c> is an instance of <c>GlobalParameters</c> class.</param>
        protected Dictionary<string, byte[]> SigncryptTheMessage(string message, BigInteger _PublicKeyReceiver, 
            BigInteger _Beta, BigInteger _KeyK1, GlobalParameters globalParameters)
        {
            Dictionary<string, byte[]> SignCryptValues = new Dictionary<string, byte[]>();

            BigInteger ComputedValueA1;
            BigInteger ComputedValueA2;
            byte[] ComputedValueKey2;
            byte[] ComputedValueA1Final;
            byte[] ComputedValueA2Final;
            byte[] ComputedValueR;
            byte[] ComputedValueC;

            ComputedValueA1 = ComputeA1(_Beta, globalParameters);
            ComputedValueA2 = ComputeA2(_Beta, _KeyK1, _PublicKeyReceiver, globalParameters.RandomNumberN);          
            ComputedValueA1Final = ComputedValueA1.ToByteArray();
            ComputedValueA2Final = ComputedValueA2.ToByteArray();

            ComputedValueKey2 = this.ComputeKeyK2(_KeyK1);

            //ComputedValueKey2 is being resized because of the fact that Rijndael Algorithm accepts 256 bit key
            Array.Resize(ref ComputedValueKey2, 32);  

            ComputedValueC = EncryptMessageWithKey2(message, ComputedValueKey2, globalParameters.RijndaelCryptoSystem.IV);
            ComputedValueR = SignMessageWithKey2(message, ComputedValueKey2);


            /*
             * Adding computed values to the list for sending it to the receiver.
             */
            SignCryptValues.Add(ConstantValuesSigncryption.A1, ComputedValueA1Final);
            SignCryptValues.Add(ConstantValuesSigncryption.A2, ComputedValueA2Final);
            SignCryptValues.Add(ConstantValuesSigncryption.C, ComputedValueC);
            SignCryptValues.Add(ConstantValuesSigncryption.R, ComputedValueR);


            return SignCryptValues;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method computes the A1 value in the signcryption process.
        /// (<paramref name="_beta"/>,<paramref name="globalParameters"/>).
        /// </summary>
        /// <returns>
        /// A big integer, computed A1.
        /// </returns>
        /// <remarks>
        /// It computes A1 value as following; A1=g^{beta}modN.
        /// </remarks>
        /// <param><c>_beta</c> is a computed value by the sender.</param>
        /// <param><c>globalParameters</c> is an instance of <c>GlobalParameters</c> class.</param>
        private BigInteger ComputeA1(BigInteger _beta, GlobalParameters globalParameters)
        {
            return BigInteger.ModPow(globalParameters.RandomNumberG, _beta, globalParameters.RandomNumberN);
        }


        /// <summary>
        /// This method computes the A1 value in the signcryption process.
        /// (<paramref name="_beta"/>,<paramref name="_keyK1"/>,<paramref name="_PublicKeyReceiver"/>,<paramref name="_RandomNumberN"/>).
        /// </summary>
        /// <returns>
        /// A big integer, computed A2.
        /// </returns>
        /// <remarks>
        /// It computes A2 value as following; A2=k1*(y^{beta})modN.
        /// </remarks>
        /// <param><c>_beta</c> is a computed secret value by the sender.</param>
        /// <param><c>_keyK1</c> is a randomly chosen secret key by the sender.</param>
        /// <param><c>_PublicKeyReceiver</c> is a public of the receiver.</param>
        /// <param><c>_RandomNumberN</c> is a computed large number N.</param>
        private BigInteger ComputeA2(BigInteger _beta, BigInteger _keyK1, BigInteger _PublicKeyReceiver, BigInteger _RandomNumberN)
        {
            return (BigInteger.Multiply(_keyK1, BigInteger.Pow(_PublicKeyReceiver, (int)_beta)) % _RandomNumberN);
        }


        /// <summary>
        /// This method computes the C value in the signcryption process.
        /// (<paramref name="_message"/>,<paramref name="_keyK2"/>,<paramref name="_IV"/>).
        /// </summary>
        /// <returns>
        /// A byte array, encrypted message with key2.
        /// </returns>
        /// <remarks>
        /// It computes A2 value as following; A2=k1*(y^{beta})modN.
        /// </remarks>
        /// <param><c>_message</c> is a message to be encrypted by the Rijndael Algorithm.</param>
        /// <param><c>_keyK2</c> is a hashed value of the key1.</param>
        /// <param><c>_IV</c> is an initilization vector being used by the Rijndael encryption algorithm in the first round.</param>
        private byte[] EncryptMessageWithKey2(string _message, byte[] _keyK2, byte[] _IV)
        {
            return Computation.EncryptStringToBytes_Aes(_message, _keyK2, _IV);
        }
        #endregion
    }
}
