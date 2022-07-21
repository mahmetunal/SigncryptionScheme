using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SigncryptionScheme.Computations
{
    public static class ConstantValeus
    {
        public static BigInteger startPoint = new BigInteger(Math.Pow(2, 8));
        public static BigInteger endPoint = new BigInteger(Math.Pow(2, 9));
        public static BigInteger lowerLimitofQ = new BigInteger(10); 
    }
}
