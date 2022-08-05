using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionProposed.Computations
{
    /// <summary>
    /// Class <c>BigIntegerPrimeTest</c> is being used for both testing
    /// any big integer whether or not prime, or finding for relative 
    /// primes of given big integer. This class is publicly accessible.
    /// </summary>
    public class BigIntegerPrimeTest
    {
        #region Public Methods
        /// <summary>
        /// This method finds the factors of the given number
        /// Contribution: this method is obtained and adapted from the stackoverflow forum
        /// https://stackoverflow.com/questions/239865/best-way-to-find-all-factors-of-a-given-number
        /// (<paramref name="number"/>).
        /// </summary>
        /// <returns>
        /// A list of Big Integer that stores the factor of the given number
        /// </returns>
        /// <param><c>number</c> is a big integer number of factors to be found.</param>
        public List<BigInteger> Factors(BigInteger number)
        {
            var factors = new List<BigInteger>();
            BigInteger max = new BigInteger(Math.Sqrt((double)number));

            /*
             * "Test from 1 to the square root, or the int below it, inclusive."
             */
            for (BigInteger factor = 1; factor <= max; ++factor) 
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                        factors.Add(number / factor);
                }
            }
            return factors;
        }

        /// <summary>
        /// This method evaluates the number given whether or not it is prime, 
        /// which is based on the Miller-Rabin primality test.
        /// Contribution: this method is obtained from @arupmondal-cs on github.
        /// https://github.com/arupmondal-cs/BigInteger-Random-Number-Generator-and-Prime-Test/blob/master/BigIntRandomGen.cs
        /// (<paramref name="source"/>,<paramref name="certainty"/>).
        /// </summary>
        /// <returns>
        /// true, if the number given is prime, otherwise false.
        /// </returns>
        /// <param><c>source</c> is a big integer number, to be found whether or not it is prime.</param>
        /// <param><c>certainty</c> is an integer that specifies how many times it is checked.</param>
        public bool IsProbablePrime(BigInteger source, int certainty)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            /*
             * "There is no built-in method for generating random BigInteger values. 
             * Instead, random BigIntegers are constructed from randomly generated 
             * byte arrays of the same length as the source."
             */
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }
        #endregion
    }
}
