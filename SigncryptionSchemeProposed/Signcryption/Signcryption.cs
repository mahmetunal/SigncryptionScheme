using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Signcryption
{
    class Signcryption : AbstractSigncryption
    {
        GlobalParameters gb = GlobalParameters.Instance();

        private BigInteger PublicKeyReceiver;
        private BigInteger beta;

        private Sender Alice;

        public Signcryption(Sender _Alice, BigInteger _PublicKeyReceiver)
        {
            this.Alice = _Alice;
            this.PublicKeyReceiver = _PublicKeyReceiver;
            this.beta = this.Alice.GeneratedNumberBeta;
        }

        public Dictionary<string, byte[]> SigncryptTheMessage(string message)
        {
            Dictionary<string, byte[]> SignCryptValues = new Dictionary<string, byte[]>();
            BigInteger Keyk1 = this.Alice.SecretKey;

            BigInteger ComputedValueA1;
            BigInteger ComputedValueA2;
            byte[] ComputedValueKey2;
            byte[] ComputedValueKey1;

            byte[] ComputedValueA1Final;
            byte[] ComputedValueA2Final;
            byte[] ComputedValueR;
            byte[] ComputedValueC;

            /*ComputedValueKey1 = Computation.HashBigIntegerToBytes_SHA1(this.Alice.SecretKey);
            Keyk1 = new BigInteger(ComputedValueKey1);*/

            ComputedValueA1 = ComputeA1(this.beta);
            ComputedValueA2 = ComputeA2(this.beta, this.Alice.SecretKey, this.PublicKeyReceiver);
            Console.WriteLine("Actual A1: {0}, A2: {1}", ComputedValueA1, ComputedValueA2);
            
            ComputedValueA1Final = ComputedValueA1.ToByteArray();
            ComputedValueA2Final = ComputedValueA2.ToByteArray();

            ComputedValueKey2 = this.ComputeKeyK2(Keyk1);

            //It is being resized because of the fact that Rijndael Algorithm accepts 256 bit key
            Array.Resize(ref ComputedValueKey2, 32);  

            ComputedValueC = EncryptMessageWithKey2(message, ComputedValueKey2);
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

        private BigInteger ComputeA1(BigInteger _beta)
        {
            return BigInteger.ModPow(gb.RandomNumberG, _beta, gb.RandomNumberN);
        }

        private BigInteger ComputeA2(BigInteger _beta, BigInteger _keyK1, BigInteger _PublicKeyReceiver)
        {
            return (BigInteger.Multiply(_keyK1, _PublicKeyReceiver ^ _beta) % gb.RandomNumberN);
        }


        private byte[] EncryptMessageWithKey2(string _message, byte[] _keyK2)
        {
            return Computation.EncryptStringToBytes_Aes(_message, _keyK2, gb.RijndaelCryptoSystem.IV);
        }

    }
}
