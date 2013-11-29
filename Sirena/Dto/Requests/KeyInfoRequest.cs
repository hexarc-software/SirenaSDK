using System;
using System.Xml.Serialization;

namespace Sirena
{
    /// <summary>
    /// Represents the Sirena key info request.
    /// </summary>
    [XmlRoot("sirena")]
    public sealed class KeyInfoRequest : DtoRequest
    {
        [XmlElement("query")]
        public KeyInfoQuery Query { get; set; }

        public KeyInfoRequest() 
        {
            Query = new KeyInfoQuery();
        }
    }

    public sealed class KeyInfoQuery
    {
        [XmlElement("key_info")]
        public KeyInfoQueryParams Params { get; set; }

        public KeyInfoQuery()
        {
            Params = new KeyInfoQueryParams();
        }
    }

    public sealed class KeyInfoQueryParams
    {
        [XmlElement("answer_params")]
        public KeyInfoAnswerParams AnswerParams { get; set; }

        public KeyInfoQueryParams()
        {
            AnswerParams = new KeyInfoAnswerParams();
        }
    }

    public sealed class KeyInfoAnswerParams
    {
        [XmlElement("lang")]
        public String LanguageParams { get; set; }

        public KeyInfoAnswerParams()
        {
            LanguageParams = "eng";
        }
    }
}
