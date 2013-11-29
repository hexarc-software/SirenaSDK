using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirena
{
    /// <summary>
    /// Represents errors that occur during during messaging with the Sirena server.
    /// </summary>
    public sealed class SirenaException : Exception
    {
        /// <summary>
        /// Initializes an instance of the SirenaException class.
        /// </summary>
        public SirenaException()
            : base()
        {
        }

        /// <summary>
        /// Initializes an instance of the SirenaException class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public SirenaException(String message)
            : base(message)
        {
        }
    }
}
