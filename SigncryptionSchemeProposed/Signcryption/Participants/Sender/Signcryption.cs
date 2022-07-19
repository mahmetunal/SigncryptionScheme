using SigncryptionScheme.Signcryption.Participants;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Signcryption.Participants.Sender
{
    public class Signcryption : AbstractSigncryption
    {
        private readonly GlobalParameters gb = GlobalParameters.Instance();

        public Signcryption()
        {

        }

        public Dictionary<string, byte[]> SigncryptTheMessage(string message, BigInteger _PublicKeyReceiver, BigInteger _Beta, BigInteger _KeyK1)
        {
            Dictionary<string, byte[]> SignCryptValues = new Dictionary<string, byte[]>();
            

            BigInteger ComputedValueA1;
            BigInteger ComputedValueA2;
            byte[] ComputedValueKey2;
            byte[] ComputedValueA1Final;
            byte[] ComputedValueA2Final;
            byte[] ComputedValueR;
            byte[] ComputedValueC;

            ComputedValueA1 = ComputeA1(_Beta);
            ComputedValueA2 = ComputeA2(_Beta, _KeyK1, _PublicKeyReceiver);
            Console.WriteLine("Actual A1: {0}, A2: {1}", ComputedValueA1, ComputedValueA2);
            
            ComputedValueA1Final = ComputedValueA1.ToByteArray();
            ComputedValueA2Final = ComputedValueA2.ToByteArray();

            ComputedValueKey2 = this.ComputeKeyK2(_KeyK1);

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
            return (BigInteger.Multiply(_keyK1, BigInteger.Pow(_PublicKeyReceiver, (int)_beta)) % gb.RandomNumberN);
        }


        private byte[] EncryptMessageWithKey2(string _message, byte[] _keyK2)
        {
            return Computation.EncryptStringToBytes_Aes(_message, _keyK2, gb.RijndaelCryptoSystem.IV);
        }

    }
}
