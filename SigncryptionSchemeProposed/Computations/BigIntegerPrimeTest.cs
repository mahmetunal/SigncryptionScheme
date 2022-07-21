using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SigncryptionScheme.Computations
{
    // Miller-Rabin primality test as an extension method on the BigInteger type.
    // Based on the Ruby implementation on this page.
    public class BigIntegerPrimeTest
    {
        public List<BigInteger> Factors(BigInteger number)
        {
            var factors = new List<BigInteger>();
            BigInteger max = new BigInteger(Math.Sqrt((double)number));  // Round down

            for (BigInteger factor = 1; factor <= max; ++factor) // Test from 1 to the square root, or the int below it, inclusive.
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor) // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                }
            }
            return factors;
        }

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

            // There is no built-in method for generating random BigInteger values.
            // Instead, random BigIntegers are constructed from randomly generated
            // byte arrays of the same length as the source.
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    // This may raise an exception in Mono 2.10.8 and earlier.
                    // http://bugzilla.xamarin.com/show_bug.cgi?id=2761
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

        public BigInteger FindPrimitiveRoots(BigInteger _primeNumber)
        {

            // Find value of Euler Totient function of n
            // Since n is a prime number, the value of Euler
            // Totient function is n-1 as there are n-1
            // relatively prime numbers.
            BigInteger phi = _primeNumber - 1;

            // Find prime factors of phi and store in a List
            List<BigInteger> source = Factors(phi);

            // Check for every number from 2 to phi
            for (BigInteger iterator = 2; iterator <= phi; iterator++)
            {
                // Iterate through all prime factors of phi.
                // and check if we found a power with value 1
                bool flag = false;
                foreach(BigInteger bg in source)
                {

                    // Check if iterator^((phi)/primefactors) mod p
                    // is 1 or not

                    flag = Power(iterator, phi / bg, _primeNumber) == BigInteger.One;

                    if (!flag)
                        return iterator;
                }

            }

            // If no primitive root found
            return BigInteger.MinusOne;
        }

        public BigInteger Power(BigInteger x, BigInteger y, BigInteger p)
        {
            BigInteger res = BigInteger.One;     // Initialize result

            x %= p; // Update x if it is more than or equal to p

            while (y > 0)
            {
                // If y is odd, multiply x with result
                if (y % 2 == 1)
                {
                    res = (res * x) % p;
                }

                // y must be even now
                y >>= 1; // y = y/2
                x = (x * x) % p;
            }
            return res;
        }

        public BigInteger CalculatePrimitiveRootForPrimeModulo(BigInteger _primeNumber)
        {

            BigInteger phi = _primeNumber - 1;

            if (_primeNumber < 4)
                return phi;

            var factors = Factors(phi);

            for (BigInteger ans = 2; ans <= _primeNumber; ans++)
                if (factors.FindAll(factor => BigInteger.ModPow(ans, (phi / factor), _primeNumber) != 1).Count != 0)
                    return ans;

            throw new ArgumentException($"Primitive root for prime modulo must exist. Modulo {_primeNumber} is not prime");
        }
    }
}
