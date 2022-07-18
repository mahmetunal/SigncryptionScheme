using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionScheme
{
    public static class ConstantValuesSigncryption
    {
        public static string A1 = "A1";
        public static string A2 = "A2";
        public static string C = "C";
        public static string R = "R";
    }
    public class GlobalParameters
    {
        /**
         * Singleton design pattern is being used
         * For keeping global parameters safe 
         * And reachable from both side's key generation
         *
         **/

        static GlobalParameters instance;

        public BigInteger RandomNumberP;
        public BigInteger RandomNumberQ;
        public BigInteger RandomNumberG;
        public BigInteger RandomNumberN;
        public Aes RijndaelCryptoSystem;


        public static BigInteger startPoint = new BigInteger(Math.Pow(2, 1));
        public static BigInteger endPoint = new BigInteger(Math.Pow(2, 9));
        public static BigInteger lowerLimitofQ = new BigInteger(1);
        
        protected GlobalParameters()
        {
            this.GlobalParametersInit();
        }
        public static GlobalParameters Instance()
        {
            if (instance == null)
            {
                instance = new GlobalParameters();
            }
            return instance;
        }

        public void GlobalParametersInit()
        {
            RijndaelCryptoSystem = Aes.Create();
            this.RandomNumberP = GenerateRandomNumberP();
            this.RandomNumberQ = GenerateRandomNumberQ();
            this.RandomNumberN = GenerateRandomNumberN();
            this.RandomNumberG = GenerateRandomNumberG();
        }

        public void GenerateNewParameters()
        {
            this.GlobalParametersInit();   
        }
        private BigInteger GenerateRandomNumberP()
        {
            BigInteger tempRandomNumberP = BigInteger.Zero;
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();
            try
            {
                bool isPrimeFound = false;

                while (!isPrimeFound)
                {
                    tempRandomNumberP = RBI.RandomBigInteger(startPoint, endPoint);
                    BigIntegerPrimeTest BIPT = new BigIntegerPrimeTest();
                    isPrimeFound = BIPT.IsProbablePrime(tempRandomNumberP, 100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("_primeNumberP\nException Occured: {0} !!", e.Message);
                return BigInteger.Zero;
            }

            return tempRandomNumberP;
        }

        private BigInteger GenerateRandomNumberQ()
        {
            BigInteger tempRandomNumberQ = BigInteger.Zero;
            List<BigInteger> primeFactors;

            Random rnd = new Random();

            try
            {
                bool isPrimeNotFound = true;
                while (isPrimeNotFound)
                {

                    BigIntegerPrimeTest BIPT = new BigIntegerPrimeTest();

                    primeFactors = BIPT.Factors(RandomNumberP - 1);
                    primeFactors.Reverse();

                    primeFactors = primeFactors.FindAll(
                        delegate (BigInteger bg)
                        {
                            return BIPT.IsProbablePrime(bg, 100) && bg > lowerLimitofQ;
                        }
                    );

                    isPrimeNotFound = primeFactors.Count == 0;

                    if (!isPrimeNotFound)
                    {
                        int indexOfList = rnd.Next(primeFactors.Count);
                        tempRandomNumberQ = primeFactors[indexOfList];
                    }
                    else
                        RandomNumberP = this.GenerateRandomNumberP();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("_primeNumber\nException Occured: {0} !!", e.Message);
            }


            return tempRandomNumberQ;
        }

        private BigInteger GenerateRandomNumberG()
        {
            RandomBigIntegerGenerator RBI = new RandomBigIntegerGenerator();
            return RBI.RandomBigInteger(BigInteger.Zero, RandomNumberN - 1);
        }

        private BigInteger GenerateRandomNumberN()
        {
            return BigInteger.Multiply(RandomNumberP, RandomNumberQ);
        }
    }
}
