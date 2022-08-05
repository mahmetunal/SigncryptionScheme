using SigncryptionProposed.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SigncryptionProposed.SDSS1.Participants.Receiver
{
    public class UnsigncryptionSDSS1 : AbstractSigncryptionSDSS1
    {
        GlobalParametersSDSS1 globalParametersSdss1 = GlobalParametersSDSS1.Instance();

        public UnsigncryptionSDSS1()
        {

        }

        protected bool UnsigncryptTheMessage(Dictionary<string, byte[]> _signcryptValues, BigInteger _PrivateKeyOfReceiver, 
            BigInteger _PublicKeyOfSender, out string obtainedMessageOut)
        {
            byte[] valueS;
            byte[] valueC;
            byte[] valueR;
            byte[] valuePrimeR;
            BigInteger ObtainedMasterKey;
            string obtainedMessage;
            byte[] hashedK1, hashedK2, masterHash;

            valueS = _signcryptValues[ConstantValuesSigncryptionSDSS1.S];
            valueC = _signcryptValues[ConstantValuesSigncryptionSDSS1.C];
            valueR = _signcryptValues[ConstantValuesSigncryptionSDSS1.R];


            ObtainedMasterKey = this.ObtainMasterKey(valueR, valueS, _PrivateKeyOfReceiver, _PublicKeyOfSender);
            
            masterHash = HashTheValueComputed(ObtainedMasterKey);
            //masterHash = _signcryptValues[ConstantValuesSigncryptionSDSS2.Key];
            int mid = (masterHash.Length + 1) / 2;
            hashedK1 = masterHash.Take(mid).ToArray();
            hashedK2 = masterHash.Skip(mid).ToArray();

            Array.Resize(ref hashedK1, 32);

            obtainedMessage = DecryptMessageWithKey1(valueC, hashedK1);
            valuePrimeR = SignMessageWithKey2(obtainedMessage, hashedK2);
            bool isVerified = this.VerifyTheMessage(valueR, valuePrimeR);

            if (isVerified)
                obtainedMessageOut = obtainedMessage;
            else
                obtainedMessageOut = "Message could not authenticated.";

            return isVerified;
        }

        private BigInteger ObtainMasterKey(byte [] _ValueR, byte[] _ValueS, BigInteger _PrivateKey, BigInteger _PublicKeyOfSender)
        {
            BigInteger valueS = new BigInteger(_ValueS);
            BigInteger valueR = ComputeR(_ValueR, globalParametersSdss1.RandomNumberQ);

            BigInteger tempValue0 = BigInteger.Multiply(valueS, _PrivateKey);
            BigInteger tempValue1 = BigInteger.ModPow(globalParametersSdss1.RandomNumberG, BigInteger.Multiply(tempValue0, valueR), globalParametersSdss1.RandomNumberP);
            BigInteger tempValue2 = BigInteger.ModPow(_PublicKeyOfSender, tempValue0, globalParametersSdss1.RandomNumberP);
            return BigInteger.Multiply(tempValue1, tempValue2) % globalParametersSdss1.RandomNumberP;
        }

        private string DecryptMessageWithKey1(byte[] _cipherText, byte[] _keyK1)
        {
            return Computation.DecryptStringFromBytes_Aes(_cipherText, _keyK1, globalParametersSdss1.RijndaelCryptoSystem.IV);
        }

        private byte[] HashTheValueComputed(BigInteger _value)
        {
            return Computation.HashBigIntegerToBytes_SHA1(_value);
        }

        private bool VerifyTheMessage(byte[] _Rvalue, byte[] _Rprime)
        {
            return _Rprime.SequenceEqual(_Rvalue);
        }
    }
}
