using System;
using System.Security.Cryptography;

namespace Sirena.Cryptography
{
    /// <summary>
    /// Provides RSA cryptography compatible with the Sirena messaging technique. 
    /// </summary>
    public sealed class RSACryptography
    {
        private RSACryptoServiceProvider _rsa;

        private SHA1CryptoServiceProvider _sha1;

        /// <summary>
        /// Initializes an instance of the RSACryptography class.
        /// </summary>
        public RSACryptography()
        {
            _rsa = new RSACryptoServiceProvider();
            _sha1 = new SHA1CryptoServiceProvider();
        }

        /// <summary>
        /// Ecrypts data with a given key.
        /// </summary>
        /// <param name="key">The RSA key that used for encrypting.</param>
        /// <param name="data">The data to encrypt.</param>
        /// <returns>Returns a byte array that contains the ecnrypted data.</returns>
        public Byte[] Encrypt(RSAParameters key, Byte[] data)
        {
            _rsa.Clear();
            _rsa.ImportParameters(key);

            return _rsa.Encrypt(data, false);
        }

        /// <summary>
        /// Signs data with a given key.
        /// </summary>
        /// <param name="key">The RSA key that used for signing.</param>
        /// <param name="data">The data to sign.</param>
        /// <returns>Returns a byte array that contains the signed data.</returns>
        public Byte[] Sign(RSAParameters key, Byte[] data)
        {
            _rsa.Clear();
            _rsa.ImportParameters(key);

            return _rsa.SignData(data, 0, data.Length, _sha1);
        }
    }
}
