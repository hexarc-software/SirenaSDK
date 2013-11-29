using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sirena.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Parses the enum object from a string that
        /// used in one of XmlEnum attributes.
        /// </summary>
        /// <param name="type">The enum type that contains XmlEnum attributes.</param>
        /// <param name="value">The string to parse.</param>
        /// <returns>Returns the parsed enum value.</returns>
        public static Object ParseXmlEnumName(Type type, String value)
        {
            return ParseXmlEnumName(type, value, false);
        }

        /// <summary>
        /// Parses the enum object from a string that
        /// used in one of XmlEnum attributes. 
        /// </summary>
        /// <param name="type">The enum type that contains XmlEnum attributes</param>
        /// <param name="value">The string to parse.</param>
        /// <param name="ignoreCase">The flag that specifies case sensitive parsing option.</param>
        /// <returns>Returns the parsed enum value.</returns>
        public static Object ParseXmlEnumName(Type type, String value, Boolean ignoreCase)
        {
            var output = default(Object);
            var enumStringValue = default(String);

            if (!type.IsEnum)
            {
                throw new ArgumentException(String.Format("Supplied type must be an Enum. Type was {0}", type));
            }

            foreach (var fi in type.GetFields())
            {
                var attribute = fi.GetCustomAttribute(typeof(XmlEnumAttribute)) as XmlEnumAttribute;
                if (attribute != null)
                {
                    enumStringValue = attribute.Name;
                }

                if (String.Compare(enumStringValue, value, ignoreCase) == 0)
                {
                    output = Enum.Parse(type, fi.Name);
                    break;
                }
            }

            if (output == null)
            {
                throw new InvalidOperationException("Could not parse the given value. No XmlEnum value has been found.");
            }

            return output;
        }

        /// <summary>
        /// Gets the XmlEnum name associated with a give enum value.
        /// </summary>
        /// <param name="type">The given enum type</param>
        /// <param name="value">The enum value to find the associated XmlEnum name.</param>
        /// <returns>Returns the XmlEnum name associated with the given enum value.</returns>
        public static String GetXmlEnumName(this Enum value)
        {
            var type = value.GetType();
            var info = type.GetField(value.ToString("G"));

            if (!info.IsDefined(typeof(XmlEnumAttribute), false))
            {
                throw new InvalidOperationException("There's no XmlAttribute on the given enum value.");
            }

            var objects = info.GetCustomAttributes(typeof(XmlEnumAttribute), false);
            var attribute = (XmlEnumAttribute)objects[0];
            return attribute.Name;
        }
    }
}
