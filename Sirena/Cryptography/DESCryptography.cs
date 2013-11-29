using System;
using System.Security.Cryptography;

namespace Sirena.Cryptography
{
    /// <summary>
    /// Provides DES Cryptography compatible
    /// with the Sirena GDS messaging technique.
    /// </summary>
    public sealed class DESCryptography
    {
        private static DESCryptography _instance = new DESCryptography();

        /// <summary>
        /// Gets the instance of the DESCryptography class.
        /// </summary>
        public static DESCryptography Instance
        {
            get
            {
                return _instance;
            }
        }

        #region Fields

        private DESCryptoServiceProvider _DES;

        private ICryptoTransform _encryptor;

        private ICryptoTransform _decryptor;

        #endregion

        /// <summary>
        /// Gets the DES key that used for
        /// encrypting messages.
        /// </summary>
        public Byte[] Key
        {
            get
            {
                return _DES.Key;
            }
        }

        /// <summary>
        /// Gets the unique id of the object.
        /// </summary>
        public Int32 Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Initilaizes an instance of the DESCryptography class.
        /// </summary>
        private DESCryptography()
        {
            Id = new Random().Next();

            _DES = new DESCryptoServiceProvider();
            _DES.Padding = PaddingMode.PKCS7;
            _DES.Mode = CipherMode.ECB;
            _DES.GenerateKey();

            _encryptor = _DES.CreateEncryptor();
            _decryptor = _DES.CreateDecryptor();
        }

        /// <summary>
        /// Encrypts a given data.
        /// </summary>
        /// <param name="data">A data to encrypt.</param>
        /// <returns>Returns the encrypted version of a given data.</returns>
        public Byte[] Encrypt(Byte[] data)
        {
            return _encryptor.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// Decrypts a given data.
        /// </summary>
        /// <param name="data">A data to decrypt.</param>
        /// <returns>Returns the decrypted version of a give data.</returns>
        public Byte[] Decrypt(Byte[] data)
        {
            return _decryptor.TransformFinalBlock(data, 0, data.Length);
        }
    }
}
