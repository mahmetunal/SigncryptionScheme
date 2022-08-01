using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Computations
{
    /// <summary>
    /// Class <c>ConstantValeus</c> stores constant values that
    /// are being used by every sender and receiver.
    /// </summary>
    public static class ConstantValeus
    {
        #region Properties
        /// <summary>
        /// Instance variable <c>startPointc> represents the minimum value
        /// of big integer that are produced randomly within a specific range.
        /// </summary>
        public static BigInteger startPoint = new BigInteger(Math.Pow(2, 8));

        /// <summary>
        /// Instance variable <c>endPoint</c> represents the maximum value
        /// of big integer that are produced randomly within a specific range.
        /// </summary>
        public static BigInteger endPoint = new BigInteger(Math.Pow(2, 9));

        /// <summary>
        /// Instance variable <c>lowerLimitofQ</c> represents minimum value
        /// of Random Number Q. In this case, it could not be less than 10.
        /// </summary>
        public static BigInteger lowerLimitofQ = new BigInteger(10);
        #endregion
    }
}
