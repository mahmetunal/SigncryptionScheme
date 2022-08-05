using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionScheme.SDSS1
{
    public static class ConstantValuesSigncryptionSDSS1
    {
        public static string S = "S";
        public static string C = "C";
        public static string R = "R";
    }
    public class GlobalParametersSDSS1
    {
        /**
         * Singleton design pattern is being used
         * For keeping global parameters safe 
         * And reachable from both side's key generation
         *
         **/

        static GlobalParametersSDSS1 instance;

        public BigInteger RandomNumberP;
        public BigInteger RandomNumberQ;
        public BigInteger RandomNumberG;
        public Aes RijndaelCryptoSystem;
        public List<BigInteger> ListContainingAllQValues;
        public List<BigInteger> ListContainingAllPValues;
        public List<BigInteger> RelativePrimesOfQ;
        public List<BigInteger> RelativePrimesOfP;
        
        protected GlobalParametersSDSS1()
        {
            this.GlobalParametersInit();
        }
        public static GlobalParametersSDSS1 Instance()
        {
            if (instance == null)
            {
                instance = new GlobalParametersSDSS1();
            }
            return instance;
        }

        private void GlobalParametersInit()
        {
            RijndaelCryptoSystem = Aes.Create();
            this.RandomNumberP = GenerateRandomNumberP();
            this.RandomNumberQ = GenerateRandomNumberQ();
            this.ListContainingAllQValues = ContainingAllElementsofList(RandomNumberQ);
            this.ListContainingAllPValues = ContainingAllElementsofList(RandomNumberP);
            this.RelativePrimesOfQ = FindingRelativePrimes(ListContainingAllQValues, RandomNumberQ);
            this.RelativePrimesOfP = FindingRelativePrimes(ListContainingAllPValues, RandomNumberP);
            this.RandomNumberG = ComputeRandomNumberG();
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
                    tempRandomNumberP = RBI.RandomBigInteger(ConstantValeus.startPoint, ConstantValeus.endPoint);
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
                            return BIPT.IsProbablePrime(bg, 100) && bg > ConstantValeus.lowerLimitofQ;
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

        private BigInteger CalculatePhiEulerFunction(BigInteger _primeNumberP)
        {
            return _primeNumberP - 1;
        }

        private BigInteger ComputeRandomNumberG()
        {
            BigInteger NumberG = BigInteger.Zero;
            BigInteger PhiEulerResult = CalculatePhiEulerFunction(RandomNumberP);

            List<BigInteger> list = this.RelativePrimesOfP.FindAll(x => BigInteger.ModPow(x, PhiEulerResult, RandomNumberP) == 1);
            //List<BigInteger> list = this.RelativePrimesOfQ.FindAll(x => BigInteger.ModPow(x, PhiEulerResult, RandomNumberQ) == 1 && x != 1);


            if (list.Count == 0)
            {
                GenerateNewParameters();
            }
            else
            {
                NumberG = SelectingRandomListValue(list);
            }
            return NumberG;
        }

        private List<BigInteger> ContainingAllElementsofList(BigInteger value)
        {
            List<BigInteger> elementsList = new List<BigInteger>();
            for (BigInteger i = 1; i <= value; i++)
            {
                elementsList.Add(i);
            }
            return elementsList;
        }

        private List<BigInteger> FindingRelativePrimes(List<BigInteger> _Values, BigInteger _RandomNumber)
        {
            List<BigInteger> RelativePrimesOfNumber = _Values.FindAll(x => BigInteger.GreatestCommonDivisor(x, _RandomNumber) == 1);

            if (RelativePrimesOfNumber.Count == 0)
            {
                GenerateNewParameters();
            }

            return RelativePrimesOfNumber;
        }

        public BigInteger SelectingRandomListValue(List<BigInteger> _list)
        {
            Random rnd = new Random();
            int index = rnd.Next(1, _list.Count-1);
            return _list[index];
        }

    }
}
