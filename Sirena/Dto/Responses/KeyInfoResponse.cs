using System;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class KeyInfoResponse : DtoResponse
    {
        [XmlElement("answer")]
        public KeyAnswer Answer { get; set; }
    }

    public sealed class KeyAnswer
    {
        [XmlAttribute("pult")]
        public String Pult { get; set; }

        [XmlElement("key_info")]
        public KeyAnswerBody Body { get; set; }
    }

    public sealed class KeyAnswerBody
    {
        [XmlElement("key_manager")]
        public KeyManager KeyManager { get; set; }

        [XmlElement("error")]
        public Error Error { get; set; }

        /// <summary>
        /// Gets the additional info about the response.
        /// </summary>
        [XmlElement("info")]
        public Info Info { get; set; }
    }

    public sealed class KeyManager
    {
        [XmlElement("key")]
        public KeyDigest KeyDigest { get; set; }

        [XmlElement("expiration")]
        public String Expiration { get; set; }

        [XmlElement("unconfirmed")]
        public String Unconfirmed { get; set; }

        [XmlElement("server_public_key")]
        public String ServerPublicKey { get; set; }
    }

    public sealed class KeyDigest
    {
        [XmlAttribute("state")]
        public KeyState KeyState { get; set; }

        [XmlText]
        public String Text { get; set; }
    }

    public enum KeyState
    {
        [XmlEnum("current")]
        Current,

        [XmlEnum("future")]
        Future,
    }
}
