using System.Numerics;


namespace SigncryptionProposed.Signcryption
{

    /// <summary>
    /// This abstract class <c>KeyGenerationAbstract</c> specifies the common functions of the key generation process.
    /// Key generation class inherits from this abstract class and should implement all abstract methods.
    /// </summary>
    public abstract class KeyGenerationAbstract
    {
        #region Protected Methods
        /// <summary>
        /// This abstract method shoul be implemented to compute Private Key of the Particaipants.
        /// (<paramref name="_RandomNumberN"/>,<paramref name="_RandomNumberG"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, private key.
        /// </returns>
        /// <remarks>
        /// Randomly chosen large number G should be both relative prime of N and
        /// satisfies this equaiton; G^{phi(N)} = 1 modN.
        /// </remarks>
        /// <param><c>_RandomNumberN</c> is a large number N.</param>
        /// <param><c>_RandomNumberG</c> is a large randomly chosen number G.</param>
        protected abstract BigInteger GeneratePrivateKey();

        /// <summary>
        /// This method actually computes random number G.
        /// (<paramref name="_RandomNumberG"/>,<paramref name="_RandomNumberN"/>,<paramref name="_PrivateKey"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, randomly chosen large number G.
        /// </returns>
        /// <remarks>
        /// Randomly chosen large number G should be both relative prime of N and
        /// satisfies this equaiton; G^{phi(N)} = 1 modN.
        /// </remarks>
        /// <param><c>_RandomNumberG</c> is a large randomly chosen number G.</param>
        /// <param><c>_RandomNumberN</c> is a large number N.</param>
        /// <param><c>_PrivateKey</c> is a private key of the pair who calls this method.</param>
        protected abstract BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberN, BigInteger _PrivateKey);
        #endregion
    }
}
