using System;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class FareremarkRequest : DtoRequest
    {
        [XmlElement("query")]
        public FareremarkQuery Query { get; set; }
    }

    public sealed class FareremarkQuery
    {
        [XmlElement("fareremark")]
        public FareremarkQueryParams Params { get; set; }
    }

    public sealed class FareremarkQueryParams
    {
        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <remarks>
        /// The string must contain 3 letters.
        /// </remarks>
        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets or sets the fare name gotten 
        /// gotten from a fare response.
        /// </summary>
        /// <remarks>
        /// The string must contain 5 letters.
        /// </remarks>
        [XmlElement("code")]
        public String FareName { get; set; }

        [XmlElement("request_params")]
        public FareremarkRequestParams RequestParams { get; set; }

        [XmlElement("answer_params")]
        public FareremarkAnswerParams AnswerParams { get; set; }
    }

    public sealed class FareremarkRequestParams
    {
        /// <summary>
        /// Gets or sets the sixteenth category for UTP.
        /// </summary>
        /// <remarks>
        /// Uses only for new UTPs.
        /// </remarks>
        [XmlElement("cat_16")]
        public Boolean CatSixteen { get; set; }

        /// <summary>
        /// Gets or sets the UPT parameters gotten from a fare response.
        /// </summary>
        [XmlElement("upt")]
        public FaresUpt Upt { get; set; }
    }

    public sealed class FareremarkAnswerParams
    {
        [XmlElement("lang")]
        public String Language { get; set; }
    }
}
