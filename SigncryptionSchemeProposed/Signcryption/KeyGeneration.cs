using System.Numerics;

namespace SigncryptionScheme.Signcryption
{
    /// <summary>
    /// This class <c>KeyGeneration</c> inherits from the <c>KeyGenerationAbstract</c> class.
    /// It should implement the abstract methods that are defined in that abstract class.
    /// This class generates public key and the private of each pairs that creates an 
    /// instance of this class and calls the correspondent methods.
    /// </summary>
    public class KeyGeneration : KeyGenerationAbstract
    {
        #region Properties
        /// <value>Property <c>PublicKey</c> represents the Public Key.</value>
        public BigInteger PublicKey;

        /// <value>Property <c>PrivateKey</c> represents the Private Key.</value>
        public BigInteger PrivateKey;

        /// <value>Property <c>globalParameters</c> represents the instance of the GlobalParameters class.</value>
        public GlobalParameters globalParameters = GlobalParameters.Instance();
        #endregion

        #region Constructor 
        /// <summary>
        /// This constructor calls the init function for initilazing private and public key properties that
        /// are being used by both sender and receiver. Every single time this constructur method is called, 
        /// it generates different keys for each pair.
        /// </summary>
        public KeyGeneration()
        {
            this.KeyGenerationInit();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method initializes public and private key properties by calling correspondent methods.
        /// </summary>
        private void KeyGenerationInit()
        {
            this.PrivateKey = GeneratePrivateKey();
            this.PublicKey = GeneratePublicKey(globalParameters.RandomNumberG, globalParameters.RandomNumberN, this.PrivateKey);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// This method is being used for generating new parameters. For example, in the case of session key expires.
        /// It calls the gb.GenerateNewParameters() method for generating new parameters for everyone, who is involved
        /// in this communication.
        /// </summary>
        protected void GenerateNewKeyes()
        {
            globalParameters.GenerateNewParameters();
            this.KeyGenerationInit();
        }

        /// <summary>
        /// This method generates the private key.
        /// </summary>
        /// <returns>
        /// A Big Integer, selected private key.
        /// </returns>
        /// <remarks>
        /// Private key is selected randomly among the relative primes of large number N.
        /// </remarks>
        protected override BigInteger GeneratePrivateKey()
        {
            return globalParameters.SelectingRandomListValue(globalParameters.RelativePrimesOfN);
        }

        /// <summary>
        /// This method generates the public key.
        /// (<paramref name="_RandomNumberG"/>,<paramref name="_RandomNumberN"/>,<paramref name="_PrivateKey"/>).
        /// </summary>
        /// <returns>
        /// A Big Integer, computed public key.
        /// </returns>
        /// <remarks>
        /// Public key is computed like: g^{x}modN
        /// g: _RandomNumberG
        /// x: _Private Key
        /// N: _RandomNumberN
        /// </remarks>
        /// <param><c>_RandomNumberG</c> is a randomly selected number G.</param>
        /// <param><c>_RandomNumberN</c> is a computed large number N.</param>
        /// <param><c>_PrivateKey</c> is a private key of the pair.</param>
        protected override BigInteger GeneratePublicKey(BigInteger _RandomNumberG, BigInteger _RandomNumberN, BigInteger _PrivateKey)
        {
            return BigInteger.ModPow(_RandomNumberG, _PrivateKey, _RandomNumberN);
        }
        #endregion
    }
}
