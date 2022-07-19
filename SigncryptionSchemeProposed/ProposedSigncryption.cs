using System;
using System.Numerics;
using System.Collections.Generic;
using SigncryptionScheme;
using SigncryptionScheme.Signcryption;
using SigncryptionScheme.Computations;
using SigncryptionScheme.Signcryption.Participants;
using SigncryptionScheme.Signcryption.Participants.Sender;
using SigncryptionScheme.Signcryption.Participants.Receiver;

namespace ProposedSigncryption
{
    class ProposedSigncryption
    {
        public static void Main(string[] args)
        {
            string message = "Hello World I am the king of encryption";
            string original = System.IO.File.ReadAllText("../../../../Datasets/dataset32768.txt");
            original = System.IO.File.ReadAllText("../../../../Datasets/dataset4911.txt");
            //original = System.IO.File.ReadAllText("../../../../Datasets/dataset106655.txt");
            message = original;
            long timeDifference;





            timeDifference = Computation.GetTimeStamp();
            Receiver Bob = new Receiver();
            Sender Alice = new Sender();
            
            Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());

            
            Console.WriteLine("Is message the same: {0}", Bob.MessageUnsigncryption(signcryptValues));
            timeDifference = Computation.GetTimeStamp() - timeDifference;

            Console.WriteLine("Time difference for Unsigncryption: {0}", timeDifference);

            #region SDSS11
#if false
            List<BigInteger> primeFactors;
            Random rnd = new Random();
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();

            BigInteger startPoint, endPoint;

            BigInteger RandomNumberP = new BigInteger();
            BigInteger RandomNumberQ = new BigInteger();
            BigInteger RandomNumberG = new BigInteger();
            BigInteger RandomNumberX = new BigInteger();

            BigInteger SecretKeyXa = new BigInteger();
            BigInteger PublicKeyYa = new BigInteger();

            try
            {
                startPoint = new BigInteger(Math.Pow(2, 10));
                endPoint = new BigInteger(Math.Pow(2, 23));
                bool isPrimeNotFound = true;
                
                while (isPrimeNotFound)
                {
                    RandomNumberP = RBI.RandomBigInteger(startPoint, endPoint);

                    BigIntegerPrimeTest BIPT = new BigIntegerPrimeTest();
                    if (BIPT.IsProbablePrime(RandomNumberP, 100))
                    {
                        Console.WriteLine("RandomP: {0}", RandomNumberP);
                        primeFactors = BIPT.Factors(RandomNumberP -1);
                        primeFactors.Reverse();

                        primeFactors = primeFactors.FindAll(
                            delegate(BigInteger bg)
                            {
                                return BIPT.IsProbablePrime(bg, 100);
                            }
                        );

                        isPrimeNotFound = primeFactors.Count == 0;

                        if (!isPrimeNotFound)
                        {
                            int indexOfList = rnd.Next(primeFactors.Count);
                            RandomNumberQ = primeFactors[indexOfList];
                            RandomNumberG = RBI.RandomBigInteger(new BigInteger(2), RandomNumberP - 2);
                            do
                            {
                                SecretKeyXa = RBI.RandomBigInteger(new BigInteger(2), RandomNumberP - 2);
                                RandomNumberX = RBI.RandomBigInteger(new BigInteger(2), RandomNumberP - 2);

                            } while (BigInteger.Compare(RandomNumberG, RandomNumberG) != 0);

                            PublicKeyYa = BigInteger.ModPow(RandomNumberG, SecretKeyXa, RandomNumberP);

                        }

                    }

                }

                Console.WriteLine("RandomP: {0}, RandomQ: {1}, RandomG: {2}, SecretKeyXa {3}, PublicKeyYa {4}, " +
                                "\nRandomX: {5}"
                                    , RandomNumberP, RandomNumberQ, RandomNumberG, SecretKeyXa, PublicKeyYa, RandomNumberX);

            }
            catch (Exception e)
            {
                Console.WriteLine("_primeNumber\nException Occured: {0} !!", e.Message);
            }

            BigInteger hashKey = BigInteger.ModPow(PublicKeyYa,RandomNumberX,RandomNumberP);
            byte[] hashedBigIntbytes = Computation.HashBigIntegerToBytes_SHA1(hashKey);

            byte[] hashedK1, hashedK2;
            int mid = (hashedBigIntbytes.Length + 1) / 2;
            hashedK1 = hashedBigIntbytes.Take(mid).ToArray();
            hashedK2 = hashedBigIntbytes.Skip(mid).ToArray();

            Array.Resize(ref hashedK1, 32);

            Aes myAes = Aes.Create();

            // Encrypt the string to an array of bytes.
            byte[] valuedC = Computation.EncryptStringToBytes_Aes(message, hashedK1, myAes.IV);
            Console.WriteLine("Encrypted value {0}", valuedC.Length);

            //byte[] valuedR = Computation.KeyedHashStringToBytes_SHA1(message, hashedK2);
            byte[] valuedR = Computation.KeyedHashBytesToBytes_SHA1(System.Text.Encoding.UTF8.GetBytes(message), hashedK2);
            //byte[] valuedRforComputing = valuedR.Take(1).ToArray();

            BigInteger valuedRBigInt = new BigInteger(value: valuedR, 
                isUnsigned: true,
                isBigEndian: true);

            /*
             
            Unsigncryption
             
             */

            BigInteger resultAfterDivide = BigInteger.Divide(RandomNumberX, valuedRBigInt + SecretKeyXa);
            //BigInteger resultAfterDivide = BigInteger.DivRem(RandomNumberX, valuedRBigInt + SecretKeyXa, out remainder);


            BigInteger valuedSforSDSS1 = resultAfterDivide % RandomNumberQ;

            byte[] valuedSforSDSS1ByteArray = valuedSforSDSS1.ToByteArray();


            BigInteger unSignValue = BigInteger.ModPow(BigInteger.Multiply(PublicKeyYa, RandomNumberG ^ valuedRBigInt),
                BigInteger.Multiply(valuedSforSDSS1,SecretKeyXa),RandomNumberP);
            


            byte[] unSignHashedKeyes = Computation.HashBigIntegerToBytes_SHA1(unSignValue);

            byte[] unSignHashedK1, unSignHashedK2;
            int unSignMid = (unSignHashedKeyes.Length + 1) / 2;
            unSignHashedK1 = unSignHashedKeyes.Take(unSignMid).ToArray();
            unSignHashedK2 = unSignHashedKeyes.Skip(unSignMid).ToArray();
            Array.Resize(ref unSignHashedK1, 32);

            Console.WriteLine("Are they equal keyes1: {0}", unSignHashedK1.AsSpan<byte>().SequenceEqual(hashedK1));
            Console.WriteLine("Are they equal keyes2: {0}", unSignHashedK2.AsSpan<byte>().SequenceEqual(hashedK2));


            byte[] decryptedMessage = Computation.DecryptByteArrayFromBytes_Aes(valuedC, unSignHashedK1, myAes.IV);


            byte[] valuedRPrime = Computation.KeyedHashBytesToBytes_SHA1(decryptedMessage
                , unSignHashedK2);
            

            //Making comparison in byte array level
            Console.WriteLine("Are they equal for enc: {0}", valuedC.AsSpan<byte>().SequenceEqual(decryptedMessage));
            Console.WriteLine("Message: {0}", System.Text.Encoding.UTF8.GetString(decryptedMessage).Equals(message));
            Console.WriteLine("Are they equal for accepting message: {0}", valuedRPrime.AsSpan<byte>().SequenceEqual(valuedR));
            Console.WriteLine("Are they equal for accepting message: {0}", valuedRPrime.AsSpan<byte>().SequenceEqual(valuedR));

#endif
            #endregion SDSS11

        }
    }
}
