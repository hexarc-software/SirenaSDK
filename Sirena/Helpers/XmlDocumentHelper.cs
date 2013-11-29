using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Sirena.Helpers
{
    /// <summary>
    /// Provides encoding extension methods for the XDocument class.
    /// </summary>
    public static class XDocumentHelper
    {
        /// <summary>
        /// Encodes the XDocument object to a string using UTF8.
        /// </summary>
        /// <param name="xdocument">The XDocument object to encode.</param>
        /// <returns>Returns a string with the UTF8 presentation of the XDocument object.</returns>
        public static String EncodeUtf8(this XDocument xdocument)
        {
            using (var stringWriter = new Utf8StringWriter())
            {
                xdocument.Save(stringWriter);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Encodes the XDocument object to a string using UTF32.
        /// </summary>
        /// <param name="xdocument">The XDocument object to encode.</param>
        /// <returns>Returns a string with the UTF32 presentation of the XDocument object.</returns>
        public static String EncodeUtf32(this XDocument xdocument)
        {
            using (var stringWriter = new Utf32StringWritter())
            {
                xdocument.Save(stringWriter);
                return stringWriter.ToString();
            }
        }
    }
}
