using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Sirena
{
    /// <summary>
    /// Contains Sirena client parameters.
    /// </summary>
    public sealed class SirenaClientSettings
    {
        /// <summary>
        /// Gets or sets the Sirena user id.
        /// </summary>
        /// <remarks>
        /// This parameter is issued by Sirena.
        /// </remarks>
        public Int32 UserId { get; set; }

        /// <summary>
        /// Gets or sets the Sirena server port.
        /// </summary>
        public Int32 Port { get; set; }

        /// <summary>
        /// Gets or sets the Sirena server host address.
        /// </summary>
        public String Host { get; set; }

        /// <summary>
        /// Gets or sets the Sirena client RSA public key.
        /// </summary>
        public RSAParameters PublicRsaKey { get; set; }

        /// <summary>
        /// Gets or sets the Sirena client RSA private key.
        /// </summary>
        public RSAParameters PrivateRsaKey { get; set; }
    }
}
