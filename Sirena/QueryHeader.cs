using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirena
{
    /// <summary>
    /// Represents the Sirena tcp protocol message header.
    /// </summary>
    public sealed class QueryHeader
    {
        /// <summary>
        /// Gets the header size.
        /// </summary>
        public const Int32 HeaderSize = 100;

        /// <summary>
        /// Gets the connection mode.
        /// </summary>
        public ConnectionMode ConnectionMode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the message length that
        /// follows after this header.
        /// </summary>
        public Int32 MessageLength
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the symmetic key id that used for data 
        /// encoding if the connection mode is symmetric.
        /// </summary>
        public Int32 SymmetricKeyId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Sirena user id issued by Sirena.
        /// </summary>
        /// <remarks>
        /// Could be found in the project properties.
        /// </remarks>
        public Int32 UserId
        {
            get;
            private set;
        }

        private readonly Byte[] _headerData = new Byte[HeaderSize];
        /// <summary>
        /// Gets the raw header data that used in the Sirena protocol messaging.
        /// </summary>
        public Byte[] HeaderData
        {
            get
            {
                return _headerData;
            }
        }

        /// <summary>
        /// Initializes an instance of the QueryHeader class.
        /// </summary>
        /// <param name="userId">The Sirena user id (issued by Sirena).</param>
        /// <param name="messageLength">The message length that will be sent.</param>
        /// <param name="connectionMode">The messaging connection mode.</param>
        /// <param name="symmetricKeyId">The symmetric key id if symmetric connection mode is used.</param>
        public QueryHeader(Int32 userId, Int32 messageLength, ConnectionMode connectionMode, Int32? symmetricKeyId = null)
        {
            UserId = userId;
            ConnectionMode = connectionMode;
            MessageLength = messageLength;
            SymmetricKeyId = symmetricKeyId ?? new Random().Next();

            //Fill header data
            var rawLength = BitConverter.GetBytes(messageLength);
            var rawDate = BitConverter.GetBytes(DateTime.Now.Ticks);
            var rawMessageId = BitConverter.GetBytes(new Random().Next());
            var rawUserId = BitConverter.GetBytes((UInt16)userId);
            var rawConnectionModeCode = GetCodeFromConnectionMode(connectionMode);
            var rawSymmetricKeyId = BitConverter.GetBytes(SymmetricKeyId);

            //Reverse all parameters gotten from BitConverter
            Array.Reverse(rawLength);
            Array.Reverse(rawDate);
            Array.Reverse(rawMessageId);
            Array.Reverse(rawUserId);
            Array.Reverse(rawSymmetricKeyId);

            //Fill header data
            Array.Copy(rawLength, 0, _headerData, 0, 4);
            Array.Copy(rawDate, 0, _headerData, 4, 4);
            Array.Copy(rawMessageId, 0, _headerData, 8, 4);
            Array.Copy(rawUserId, 0, _headerData, 44, 2);
            Array.Copy(new Byte[] { rawConnectionModeCode }, 0, _headerData, 46, 1);
            Array.Copy(rawSymmetricKeyId, 0, _headerData, 48, 4);
        }

        /// <summary>
        /// Initializes an instance of the QueryHeader class.
        /// </summary>
        /// <param name="headerData">The header raw data to initialize.</param>
        public QueryHeader(Byte[] headerData)
        {
            if (headerData.Length != QueryHeader.HeaderSize)
            {
                throw new ArgumentException(String.Format("header size must be {0}", HeaderSize));
            }

            Array.Copy(headerData, _headerData, _headerData.Length);

            var rawLength = _headerData.Take(4).ToArray();
            var rawConnectionMode = _headerData.Skip(46).First();
            var rawUserId = _headerData.Skip(44).Take(2).ToArray();
            var rawSymmetricKeyId = _headerData.Skip(48).Take(4).ToArray();

            Array.Reverse(rawLength);
            Array.Reverse(rawSymmetricKeyId);
            Array.Reverse(rawUserId);

            MessageLength = BitConverter.ToInt32(rawLength, 0);
            SymmetricKeyId = BitConverter.ToInt32(rawSymmetricKeyId, 0);
            UserId = BitConverter.ToUInt16(rawUserId, 0);
            
            ConnectionMode = GetConnectionModeFromCode(rawConnectionMode);
        }

        private Byte GetCodeFromConnectionMode(ConnectionMode connectionMode)
        {
            switch (connectionMode)
            {
                case ConnectionMode.Zipped:
                    return 0x10;
                case ConnectionMode.Symmetric:
                    return 0x08;
                case ConnectionMode.Assymmetric:
                    return 0x40;
                default:
                    return 0x0;
            }
        }

        private ConnectionMode GetConnectionModeFromCode(Byte code)
        {
            switch (code)
            {
                case 0x10:
                    return ConnectionMode.Zipped;
                case 0x08:
                    return ConnectionMode.Symmetric;
                case 0x40:
                    return ConnectionMode.Assymmetric;
                default:
                    return 0x0;
            }
        }
    }
}
