using SigncryptionScheme.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Signcryption.Participants.Receiver
{
    public class Unsigncryption : AbstractSigncryption
    {
        GlobalParameters gb = GlobalParameters.Instance();

        public Unsigncryption()
        {

        }

        protected bool UnsigncryptTheMessage(Dictionary<string, byte[]> _signcryptValues, BigInteger _PrivateKeyOfReceiver)
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

            ObtainedKey1 = this.ObtainKeyK1(valueA1, valueA2, _PrivateKeyOfReceiver);
            Key2 = this.ComputeKeyK2(ObtainedKey1);
            Array.Resize(ref Key2, 32);

            obtainedMessage = this.DecryptMessageWithKey2(valueC, Key2);;
            valuePrimeR = this.SignMessageWithKey2(obtainedMessage, Key2);

            return this.VerifyTheMessage(valueR, valuePrimeR);
        }

        private BigInteger ObtainKeyK1(byte [] _ValueA1, byte[] _ValueA2, BigInteger _PrivateKey)
        {
            BigInteger computedValueKeyK1;
            BigInteger valueA1;
            BigInteger valueA2;

            valueA1 = new BigInteger(_ValueA1);
            valueA2 = new BigInteger(_ValueA2);

            BigInteger tempValue1 = BigInteger.Pow(valueA1, (int)_PrivateKey) % gb.RandomNumberN;

            List<BigInteger> tempList = gb.ListContainingAllNValues.FindAll(x => BigInteger.Multiply(x, tempValue1) % gb.RandomNumberN == 1);

            BigInteger temp = BigInteger.ModPow(valueA1, _PrivateKey, gb.RandomNumberN);

            computedValueKeyK1 = BigInteger.Multiply(valueA2, tempList[0]) % gb.RandomNumberN; 

            return computedValueKeyK1;
        }

        private string DecryptMessageWithKey2(byte[] _cipherText, byte[] _keyK2)
        {
            return Computation.DecryptStringFromBytes_Aes(_cipherText, _keyK2, gb.RijndaelCryptoSystem.IV);
        }

        private bool VerifyTheMessage(byte[] _Rvalue, byte[] _Rprime)
        {
            return _Rprime.SequenceEqual(_Rvalue);
        }
    }
}
