using System;
using System.Xml.Serialization;

namespace Sirena
{
    public sealed class Error
    {
        [XmlAttribute("code")]
        public Int32 Code { get; set; }

        [XmlText]
        public String Text { get; set; }

        public override String ToString()
        {
            return String.Format("Error code: {0}, Error message: {1}", Code, Text);
        }
    }
}
