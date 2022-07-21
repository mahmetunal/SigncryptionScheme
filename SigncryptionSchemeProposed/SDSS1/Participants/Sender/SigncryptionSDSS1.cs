using SigncryptionScheme.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.SDSS1.Participants.Sender
{
    public class SigncryptionSDSS1 : AbstractSigncryptionSDSS1
    {
        private readonly GlobalParametersSDSS1 gb = GlobalParametersSDSS1.Instance();

        public SigncryptionSDSS1()
        {

        }

        protected Dictionary<string, byte[]> SigncryptTheMessage(string message, BigInteger _PublicKeyReceiver, BigInteger _RandomNumberX, BigInteger _SenderSecretKey)
        {
            Dictionary<string, byte[]> SignCryptValues = new Dictionary<string, byte[]>();
            
            BigInteger ComputedValueS;
            byte[] ComputedValueSbyte;
            byte[] ComputedValueR;
            byte[] ComputedValueC;

            byte[] hashedK1, hashedK2, masterHash;
            masterHash = ComputeMasterKey(_RandomNumberX, _PublicKeyReceiver);

            int mid = (masterHash.Length + 1) / 2;
            hashedK1 = masterHash.Take(mid).ToArray();
            hashedK2 = masterHash.Skip(mid).ToArray();

            Array.Resize(ref hashedK1, 32);
            ComputedValueC = EncryptMessageWithKey1(message, hashedK1);
            ComputedValueR = SignMessageWithKey2(message, hashedK2);

            BigInteger valueR = ComputeR(ComputedValueR, gb.RandomNumberQ);

            //BigInteger valuedRBigInt = BigInteger.Abs(new BigInteger(ComputedValueR[1]));

            ComputedValueS = ComputeS(_RandomNumberX, valueR, _SenderSecretKey);

            ComputedValueSbyte = ComputedValueS.ToByteArray();
            /*
             * Adding computed values to the list for sending it to the receiver.
             */
            SignCryptValues.Add(ConstantValuesSigncryptionSDSS1.S, ComputedValueSbyte);
            SignCryptValues.Add(ConstantValuesSigncryptionSDSS1.C, ComputedValueC);
            SignCryptValues.Add(ConstantValuesSigncryptionSDSS1.R, ComputedValueR);

            return SignCryptValues;
        }

        private byte[] ComputeMasterKey(BigInteger _RandomNumberX, BigInteger _PublicKeyReceiver)
        {
            BigInteger hashKey = BigInteger.ModPow(_PublicKeyReceiver, _RandomNumberX, gb.RandomNumberP);
            return Computation.HashBigIntegerToBytes_SHA1(hashKey);
        }

        private BigInteger ComputeS(BigInteger _RandomValueX, BigInteger _ValueR, BigInteger _SenderSecretKey)
        {
            List<BigInteger> tempList = gb.ListContainingAllQValues.FindAll(x => BigInteger.Multiply(x, (_ValueR + _SenderSecretKey)) % gb.RandomNumberQ == 1);
            BigInteger tempValue0 = BigInteger.Multiply(_RandomValueX, tempList[0]) % gb.RandomNumberQ;
            return tempValue0;
        }

        private byte[] EncryptMessageWithKey1(string _message, byte[] _keyK1)
        {
            return Computation.EncryptStringToBytes_Aes(_message, _keyK1, gb.RijndaelCryptoSystem.IV);
        }

    }
}
