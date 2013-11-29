using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sirena.Helpers
{
    /// <summary>
    /// Provides helper methods for working with cryptography.
    /// </summary>
    public static class CryptographyHelper
    {
        private static Byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };

        /// <summary>
        /// Converts a PKCS1 public key to a RSAParameters intance.
        /// </summary>
        /// <param name="pkcs1PublicKey">A PKCS1 public key to convert.</param>
        /// <returns>Returns the RSAParameters instance built from a give PKCS1 public key.</returns>
        public static RSAParameters PKCS1PublicKeyToRSAParameters(String pkcs1PublicKey)
        {
            var rsaParams = new RSAParameters();
            var publicKeyBuffer = new StringBuilder(pkcs1PublicKey);
            var rawPublicKey = default(Byte[]);

            publicKeyBuffer.Replace("-----BEGIN PUBLIC KEY-----", "");
            publicKeyBuffer.Replace("-----END PUBLIC KEY-----", "");

            try
            {
                rawPublicKey = Convert.FromBase64String(publicKeyBuffer.ToString());
            }
            catch (FormatException)
            {
                rawPublicKey = UTF8Encoding.UTF8.GetBytes(pkcs1PublicKey);
            }

            using (var memoryStream = new MemoryStream(rawPublicKey))
            {
                using (var binaryReader = new BinaryReader(memoryStream))
                {
                    var twoBytes = binaryReader.ReadUInt16();

                    if (twoBytes == 0x8130)    //data read as little endian order (actual data order for Sequence is 30 81)
                    {
                        binaryReader.ReadByte();    //advance 1 byte
                    }
                    else if (twoBytes == 0x8230)
                    {
                        binaryReader.ReadInt16();    //advance 2 bytes
                    }
                    else
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    var sequence = binaryReader.ReadBytes(15);        //read the Sequence OID
                    if (!CompareByteArrays(sequence, SeqOID))    //make sure Sequence for OID is correct
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    twoBytes = binaryReader.ReadUInt16();
                    if (twoBytes == 0x8103)    //data read as little endian order (actual data order for Bit String is 03 81)
                    {
                        binaryReader.ReadByte();    //advance 1 byte
                    }
                    else if (twoBytes == 0x8203)
                    {
                        binaryReader.ReadInt16();    //advance 2 bytes
                    }
                    else
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    var oneByte = binaryReader.ReadByte();
                    if (oneByte != 0x00)        //expect null byte next
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    twoBytes = binaryReader.ReadUInt16();
                    if (twoBytes == 0x8130)    //data read as little endian order (actual data order for Sequence is 30 81)
                    {
                        binaryReader.ReadByte();    //advance 1 byte
                    }
                    else if (twoBytes == 0x8230)
                    {
                        binaryReader.ReadInt16();    //advance 2 bytes
                    }
                    else
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    twoBytes = binaryReader.ReadUInt16();
                    Byte lowByte = 0x00;
                    Byte highByte = 0x00;

                    if (twoBytes == 0x8102)    //data read as little endian order (actual data order for Integer is 02 81)
                    {
                        lowByte = binaryReader.ReadByte();    // read next bytes which is bytes in modulus
                    }
                    else if (twoBytes == 0x8202)
                    {
                        highByte = binaryReader.ReadByte();    //advance 2 bytes
                        lowByte = binaryReader.ReadByte();
                    }
                    else
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    Byte[] modInt = { lowByte, highByte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    Int32 modSize = BitConverter.ToInt32(modInt, 0);

                    Int32 firstByte = binaryReader.PeekChar();
                    if (firstByte == 0x00)   //if first byte (highest order) of modulus is zero, don't include it
                    {
                        binaryReader.ReadByte();    //skip this null byte
                        modSize -= 1;    //reduce modulus buffer size by 1
                    }

                    var modulus = binaryReader.ReadBytes(modSize);    //read the modulus bytes

                    if (binaryReader.ReadByte() != 0x02)            //expect an Integer for the exponent data
                    {
                        throw new InvalidDataException("Not a valid public key format");
                    }

                    var expBytes = (int)binaryReader.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    var exponent = binaryReader.ReadBytes(expBytes);

                    rsaParams.Modulus = modulus;
                    rsaParams.Exponent = exponent;
                }
            }

            return rsaParams;
        }

        private static Boolean CompareByteArrays(Byte[] leftArray, Byte[] rightArray)
        {
            if (leftArray.Length != rightArray.Length)
            {
                return false;
            }

            for (var i = 0; i < leftArray.Length; i++)
            {
                if (leftArray[i] != rightArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
