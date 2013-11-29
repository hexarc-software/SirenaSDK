namespace Sirena
{
    /// <summary>
    /// The Sirena communication connection modes.
    /// </summary>
    public enum ConnectionMode
    {
        /// <summary>
        /// Allows GZip during communication.
        /// </summary>
        Zipped = 1,

        /// <summary>
        /// Allows DES cryptography during communication.
        /// </summary>
        Symmetric = 2,

        /// <summary>
        /// Allows AES cryptography during communication.
        /// </summary>
        Assymmetric = 3,

        /// <summary>
        /// Only plain communication without cryptography and zipping.
        /// </summary>
        Plain = 4
    }
}
