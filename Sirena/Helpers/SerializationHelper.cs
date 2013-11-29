using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sirena.Helpers
{
    /// <summary>
    /// Provides helper methods for Xml serialization.
    /// </summary>
    public static class SerializationHelper
    {
        private static XmlSerializerNamespaces emptyNamespaces;

        static SerializationHelper()
        {
            emptyNamespaces = new XmlSerializerNamespaces();
            emptyNamespaces.Add("", "");
        }

        /// <summary>
        /// Serializes a Sirena DTO object to an xml string
        /// using UTF-8 encoding.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <returns>Returns a string contained the serialized object.</returns>
        public static String Serialize<T>(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value can not be null");
            }

            var serializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new Utf8StringWriter())
            {
                serializer.Serialize(stringWriter, value, emptyNamespaces);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes a Sirena DTO object from an xml string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="xml">The string contained the serialized object.</param>
        /// <returns>Returns a DTO deserialized object.</returns>
        /// <remarks>
        /// If the string is empty or null returns a default requested DTO
        /// object.
        /// </remarks>
        public static T Deserialize<T>(String xml)
        {
            if (String.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            var serializer = new XmlSerializer(typeof(T));
            var settings = new XmlReaderSettings();

            try
            {
                using (var stringReader = new StringReader(xml))
                {
                    using (var xmlReader = XmlReader.Create(stringReader))
                    {
                        return (T)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException(String.Format("Failed to deserialize the string: {0}", xml), e);
            }
        }
    }
}
