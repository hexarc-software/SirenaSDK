using System;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class FareremarkResponse : DtoResponse
    {
        [XmlElement("answer")]
        public FareremarkAnswer Answer { get; set; }
    }

    public sealed class FareremarkAnswer
    {
        /// <summary>
        /// Gets the pult name.
        /// </summary>
        [XmlAttribute("pult")]
        public String Pult { get; set; }

        /// <summary>
        /// Gets the message id.
        /// </summary>
        [XmlAttribute("msgid")]
        public String MessageId { get; set; }

        /// <summary>
        /// Gets the time when response was processed.
        /// </summary>
        [XmlIgnore]
        public DateTime? Time { get; set; }

        /// <summary>
        /// USE Time instead.
        /// </summary>
        [XmlAttribute("time")]
        public String ProxyTime
        {
            get
            {
                return (Time.HasValue) ? Time.Value.ToString("HH:mm:ss dd.MM.yyyy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Time = DateTime.ParseExact(value, "HH:mm:ss dd.MM.yyyy", null);
                }
            }
        }

        [XmlElement("fareremark")]
        public FareremarkAnswerBody Body { get; set; }
    }

    public sealed class FareremarkAnswerBody
    {
        [XmlElement("remark")]
        public FareremarkRemark Remark { get; set; }

        /// <summary>
        /// Gets the response error.
        /// </summary>
        [XmlElement("error")]
        public Error Error { get; set; }

        /// <summary>
        /// Gets the additional info about the response.
        /// </summary>
        [XmlElement("info")]
        public Info Info { get; set; }
    }

    public sealed class FareremarkRemark
    {
        [XmlIgnore]
        public Boolean NewFare { get; set; }

        [XmlAttribute("new_fare")]
        public String ProxyNewFare
        {
            get
            {
                return NewFare.ToString().ToLower();
            }
            set
            {
                NewFare = (String.IsNullOrEmpty(value)) ? false : Boolean.Parse(value);
            }
        }

        [XmlText]
        public String Text { get; set; }
    }
}
