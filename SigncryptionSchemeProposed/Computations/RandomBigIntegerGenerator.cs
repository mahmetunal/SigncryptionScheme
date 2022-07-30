using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Computations
{
    /// <summary>
    /// Class <c>RandomBigIntegerGenerator</c> is being used for
    /// generating random Big Integer.
    /// Contribution: This class is obtained from @arupmondal-cs on github.
    /// https://github.com/arupmondal-cs/BigInteger-Random-Number-Generator-and-Prime-Test/blob/master/BigIntRandomGen.cs
    /// </summary>
    class RandomBigIntegerGenerator
    {
        /// <summary>
        /// This method generates BigInteger with the given bit length.
        /// (<paramref name="bitLength"/>).
        /// </summary>
        /// <param><c>bitLength</c> is the bit length of big integer value.</param>
        public BigInteger NextBigInteger(int bitLength)
        {
            if (bitLength < 1) return BigInteger.Zero;

            int bytes = bitLength / 8;
            int bits = bitLength % 8;

            /*
             * "Generates enough random bytes to cover our bits."
             */
            Random rnd = new Random();
            byte[] bs = new byte[bytes + 1];
            rnd.NextBytes(bs);

            /*
             * "Mask out the unnecessary bits."
             */
            byte mask = (byte)(0xFF >> (8 - bits));
            bs[bs.Length - 1] &= mask;

            return new BigInteger(bs);
        }

        /// <summary>
        /// This method generates random BigInteger within the given range.
        /// (<paramref name="start"/>, <paramref name="end"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer generated in the given range
        /// </returns>
        /// <param><c>start</c> is the minimum value of the range.</param>
        /// <param><c>end</c> is the maximum value of the range.</param>
        public BigInteger RandomBigInteger(BigInteger start, BigInteger end)
        {
            if (start == end) return start;

            BigInteger res = end;

            /*
             * "Swap start and end if given in reverse order."
             */
            if (start > end)
            {
                end = start;
                start = res;
                res = end - start;
            }
            else
                /*
                 * "The distance between start and end to generate a random 
                 * BigIntger between 0 and (end-start) (non-inclusive)."
                 */
                res -= start;

            byte[] bs = res.ToByteArray();

            /*
             * "Count the number of bits necessary for res."
             */
            int bits = 8;
            byte mask = 0x7F;
            while ((bs[bs.Length - 1] & mask) == bs[bs.Length - 1])
            {
                bits--;
                if (mask.Equals(0))
                    break;
                else
                    mask >>= 1;
            }
            bits += 8 * bs.Length;

            /*
             * "Generate a random BigInteger that is the first power of 2 larger than res, 
             * then scale the range down to the size of res,
             * finally add start back on to shift back to the desired range and return."
             */
            return ((NextBigInteger(bits + 1) * res) / BigInteger.Pow(2, bits + 1)) + start;
        }
    }
}
