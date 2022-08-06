using SigncryptionScheme.Computations;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionScheme.Signcryption
{
    /// <summary>
    /// This class <c>ConstantValuesSigncryption</c> is being used for specifying
    /// constant values of the produced output in signcryption scheme. 
    /// </summary>
    public static class ConstantValuesSigncryption
    {
        #region Properties
        public static string A1 = "A1";
        public static string A2 = "A2";
        public static string C = "C";
        public static string R = "R";
        #endregion
    }

    /// <summary>
    /// This class <c>GlobalParameters</c> is being used for generating global parameters
    /// of the signcryption scheme proposed, namely; Random Prime Number P, Random Prime Number Q,
    /// Random number G, and Random Number N.
    /// </summary>
    public class GlobalParameters
    {
        /************
         * Singleton design pattern is being used
         * For keeping global parameters safe 
         * And reachable from both side's key generation
         ************/

        #region Properties
        /// <value>Property <c>instance</c> represents the instance of Global Parameters class.</value>
        static GlobalParameters globalParametersInstance;

        /// <value>Property <c>RandomNumberP</c> represents the large prime number Q.</value>
        public BigInteger RandomNumberP;

        /// <value>Property <c>RandomNumberQ</c> represents the large prime number Q.</value
        public BigInteger RandomNumberQ;

        /// <value>Property <c>RandomNumberG</c> represents the randomly chosen large number G.</value>
        public BigInteger RandomNumberG;

        /// <value>Property <c>RandomNumberN</c> represents the computed large number N (N = P*Q).</value>
        public BigInteger RandomNumberN;

        /// <value>Property <c>RijndaelCryptoSystem</c> represents Aes instance of Rijndael algorithm. Global Parameters class
        /// includes this property as both encryption and decryption process should use the same key and the same IV.
        /// In this case, it is bein generated for using the same IV not Key. Because Key value is generated in the signcryption 
        /// process and computed in the unsigncryption process</value
        public Aes RijndaelCryptoSystem;

        /// <value>Property <c>ListContainingAllNValues</c> represents the list of big integers that includes all the 
        /// numbers between 1 and N-1.</value>
        public List<BigInteger> ListContainingAllNValues;

        /// <value>Property <c>RelativePrimesOfN</c> represents the list of big integers that stores all the relative
        /// primes of N.</value>
        public List<BigInteger> RelativePrimesOfN;
        #endregion

        #region Constructor
        /// <summary>
        /// This constructor calls the init function for initilazing global parameters that
        /// are being used by both sender and receiver in signcryption and unsigncryption preocess.
        /// </summary>
        protected GlobalParameters()
        {
            this.GlobalParametersInit();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method checks whether or not there is an instance of Global Parameters class.
        /// Because global parameters are assumed that both sender and receiver agree on. Therefore,
        /// </summary>
        /// <returns>
        /// If there is an instance of this class produced prevously, it returns that instance. 
        /// Otherwise, it initalizes new class.
        /// </returns>
        public static GlobalParameters Instance()
        {
            if (globalParametersInstance == null)
            {
                globalParametersInstance = new GlobalParameters();
            }
            return globalParametersInstance;
        }

        /// <summary>
        /// If there is something wrong about the parameters, this method can be called.
        /// For instance, in the case of session expired, participants should get new keys 
        /// and they should agree on new parameters.
        /// </summary>
        public void GenerateNewParameters()
        {
            this.GlobalParametersInit();
        }


        /// <summary>
        /// This method selects random value from the given list.
        /// (<paramref name="_list"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer selected randomly.
        /// </returns>
        /// <param><c>_list</c> is a list that stores big integer values</param>
        public BigInteger SelectingRandomListValue(List<BigInteger> _list)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, _list.Count);
            return _list[index];
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method assigns all the generated values to the correspondent properties.
        /// Basically, it generates all the global parameters that both sender and receiver
        /// agreed on.
        /// </summary>
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

        /// <summary>
        /// This method generates random prime number P within the given range.
        /// </summary>
        /// <returns>
        /// A Big Integer, large prime number P.
        /// </returns>
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

        /// <summary>
        /// This method generates random prime number Q within the factors of P-1.
        /// </summary>
        /// <returns>
        /// A Big Integer, large prime number Q.
        /// </returns>
        /// <remarks>
        /// Random prime number Q satisfies that it must be both factor of P-1 and prime number.
        /// If generated random number P-1 does not have any factors, this method calls GenerateRandomNumberP  
        /// to generate new Random Prime P and continue processing with the newly generated Random Prime Number P.
        /// </remarks>
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
                            return BIPT.IsProbablePrime(bg, 100) && bg > ConstantValeus.lowestLimitofQ;
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

        /// <summary>
        /// This method generates randomly chosen large number G.
        /// </summary>
        /// <returns>
        /// A Big Integer, large number G.
        /// </returns>
        private BigInteger GenerateRandomNumberG()
        {
            return ComputeRandomNumberG(this.RandomNumberP, this.RandomNumberQ);
        }

        /// <summary>
        /// This method computes the large number N.
        /// </summary>
        /// <returns>
        /// A Big Integer, large number N.
        /// </returns>
        /// <remarks>
        /// Large number N is computed by multiplying P by Q.
        /// N = P*Q
        /// </remarks>
        private BigInteger GenerateRandomNumberN()
        {
            return BigInteger.Multiply(RandomNumberP, RandomNumberQ);
        }

        /// <summary>
        /// This method calculates the Euler's Totient function, which is also called Phi Euler Function.
        /// (<paramref name="_primeNumberP"/>,<paramref name="_primeNumberQ"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, phi euler function of N.
        /// </returns>
        /// <remarks>
        /// Phi Euler Function is calculated with using P-1 and Q-1 because both P and Q are prime numbers.
        /// Additionally, N = P*Q, Phi Euler function of N is calculated as follows.
        /// phi(N) = phi(P*Q) = (P-1)*(Q-1)
        /// </remarks>
        /// <param><c>_primeNumberP</c> is a large prime number P.</param>
        /// <param><c>_primeNumberQ</c> is a large prime number Q.</param>
        private BigInteger CalculatePhiEulerFunction(BigInteger _primeNumberP, BigInteger _primeNumberQ)
        {
            return BigInteger.Multiply(_primeNumberP - 1, _primeNumberQ - 1);
        }

        /// <summary>
        /// This method actually computes random number G.
        /// (<paramref name="_primeNumberP"/>,<paramref name="_primeNumberQ"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, randomly chosen large number G.
        /// </returns>
        /// <remarks>
        /// Randomly chosen large number G should be both relative prime of N and
        /// satisyf this equaiton; G^{phi(N)} = 1 modN.
        /// </remarks>
        /// <param><c>_primeNumberP</c> is a large prime number P.</param>
        /// <param><c>_primeNumberQ</c> is a large prime number Q.</param>
        private BigInteger ComputeRandomNumberG(BigInteger _primeNumberP, BigInteger _primeNumberQ)
        {
            BigInteger NumberG = BigInteger.Zero;
            BigInteger PhiEulerResult = CalculatePhiEulerFunction(_primeNumberP, _primeNumberQ);

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

        /// <summary>
        /// This method finds all the Relative primes of large number N.
        /// </summary>
        /// <returns>
        /// A List of Big Integers that all members of the list are relative prime of N.
        /// </returns>
        /// <remarks>
        /// Relative primes of N means that all the relative primes should satisfy this equation;
        /// Let's say x is a relative prime of N, gcd(x,N)=1
        /// </remarks>
        private List<BigInteger> FindingNsRelativePrimes()
        {
            List<BigInteger> RelativePrimesOfN = this.ListContainingAllNValues.FindAll(x => BigInteger.GreatestCommonDivisor(x, this.RandomNumberN) == 1);

            if(RelativePrimesOfN.Count == 0)
            {
                GenerateNewParameters();
            }

            return RelativePrimesOfN;
        }

        /// <summary>
        /// This method adds all the numbers to the List.
        /// (<paramref name="value"/>).
        /// </summary>
        /// <returns>
        /// A List of Big Integer that contains all the numbers between 1 and given input -1.
        /// In this case; this includes all the numbers between 1 and value-1
        /// </returns>
        /// <param><c>value</c> is a big integer value.</param>
        private List<BigInteger> ContainingAllElementsofList(BigInteger value)
        {
            List<BigInteger> listOfN = new List<BigInteger>();
            for (BigInteger i = 1; i < value; i++)
            {
                listOfN.Add(i);
            }
            return listOfN;
        }
        #endregion
    }
}
