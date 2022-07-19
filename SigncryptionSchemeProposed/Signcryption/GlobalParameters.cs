using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionScheme.Signcryption
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
        public List<BigInteger> ListContainingAllNValues;
        public List<BigInteger> RelativePrimesOfN;
        


        public static BigInteger startPoint = new BigInteger(Math.Pow(2, 5));
        public static BigInteger endPoint = new BigInteger(Math.Pow(2, 10));
        public static BigInteger lowerLimitofQ = new BigInteger(10);
        
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

        private void GlobalParametersInit()
        {
            RijndaelCryptoSystem = Aes.Create();
            this.RandomNumberP = GenerateRandomNumberP();
            this.RandomNumberQ = GenerateRandomNumberQ();
            this.RandomNumberN = GenerateRandomNumberN();
            this.ListContainingAllNValues = ContainingAllElementsofList(this.RandomNumberN);
            this.RelativePrimesOfN = FindingNsRelativePrimes();
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
            return ComputeRandomNumberG(this.RandomNumberP, this.RandomNumberQ);
        }

        private BigInteger GenerateRandomNumberN()
        {
            return BigInteger.Multiply(RandomNumberP, RandomNumberQ);
        }

        private BigInteger CalculatePhiEulerFunction(BigInteger _primeNumberP, BigInteger _primeNumberQ)
        {
            return BigInteger.Multiply(_primeNumberP - 1, _primeNumberQ - 1);
        }

        private BigInteger ComputeRandomNumberG(BigInteger _primeNumberP, BigInteger _primeNumberQ)
        {
            BigInteger NumberG = BigInteger.Zero;
            BigInteger PhiEulerResult = CalculatePhiEulerFunction(_primeNumberP, _primeNumberQ);

            //List<BigInteger> list = this.RelativePrimesOfN.FindAll(x => BigInteger.ModPow(x, _primeNumberQ - 1, PhiEulerResult) == 1);
            List<BigInteger> list = this.RelativePrimesOfN.FindAll(x => BigInteger.ModPow(x, PhiEulerResult, this.RandomNumberN) == 1);


            if (list.Count == 0)
            {
                GenerateNewParameters();
            } else
            {
                NumberG = SelectingRandomListValue(list);
            }
            return NumberG;
        }

        private List<BigInteger> FindingNsRelativePrimes()
        {
            List<BigInteger> RelativePrimesOfN = this.ListContainingAllNValues.FindAll(x => BigInteger.GreatestCommonDivisor(x, this.RandomNumberN) == 1);

            if(RelativePrimesOfN.Count == 0)
            {
                GenerateNewParameters();
            }

            return RelativePrimesOfN;
        }

        private List<BigInteger> ContainingAllElementsofList(BigInteger value)
        {
            List<BigInteger> listOfN = new List<BigInteger>();
            for (BigInteger i = 1; i < value; i++)
            {
                listOfN.Add(i);
            }
            return listOfN;
        }

        public BigInteger SelectingRandomListValue(List<BigInteger> _list)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, _list.Count);
            return _list[index];
        }
    }
}
