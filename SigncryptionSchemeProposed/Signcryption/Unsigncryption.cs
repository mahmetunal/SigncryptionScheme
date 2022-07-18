using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Signcryption
{
    class Unsigncryption : AbstractSigncryption
    {
        GlobalParameters gb = GlobalParameters.Instance();
        private Receiver Bob;

        public Unsigncryption(Receiver _Bob)
        {
            this.Bob = _Bob;
        }

        public bool UnsigncryptTheMessage(Dictionary<string, byte[]> _signcryptValues)
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

            ObtainedKey1 = this.ObtainKeyK1(valueA1, valueA2);
            Key2 = this.ComputeKeyK2(ObtainedKey1);
            Array.Resize(ref Key2, 32);

            obtainedMessage = this.DecryptMessageWithKey2(valueC, Key2);
            Console.WriteLine("Obtained message: {0}", obtainedMessage);

            valuePrimeR = this.SignMessageWithKey2(obtainedMessage, Key2);

            return this.VerifyTheMessage(valueR, valuePrimeR);
        }

        private BigInteger ObtainKeyK1(byte [] _ValueA1, byte[] _ValueA2)
        {
            BigInteger computedValueKeyK1;
            BigInteger valueA1;
            BigInteger valueA2;

            valueA1 = new BigInteger(_ValueA1);
            valueA2 = new BigInteger(_ValueA2);

            computedValueKeyK1 = BigInteger.Divide(valueA1 % gb.RandomNumberN,
                BigInteger.ModPow(valueA1, this.Bob.GetPrivateKey(), gb.RandomNumberN));

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
