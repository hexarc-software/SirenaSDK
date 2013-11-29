using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sirena
{
    public sealed class Info
    {
        [XmlElement("warning")]
        public Warning[] Warnings { get; set; }
    }

    public sealed class Warning
    {
        [XmlAttribute("level")]
        public String Level { get; set; }

        [XmlText]
        public String Text { get; set; }
    }
}
