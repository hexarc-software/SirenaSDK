using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sirena
{
    /// <summary>
    /// Represents the Sirena availability request.
    /// </summary>
    [XmlRoot("sirena")]
    public sealed class AvailabilityRequest : DtoRequest
    {
        /// <summary>
        /// Gets or sets the query data.
        /// </summary>
        /// <remarks>
        /// Required.
        /// </remarks>
        [XmlElement("query")]
        public AvailabilityQuery Query { get; set; }
    }

    /// <summary>
    /// Represents the query data that used in
    /// the Sirena availability request.
    /// </summary>
    public sealed class AvailabilityQuery
    {
        /// <summary>
        /// Gets or sets the query params.
        /// </summary>
        /// <remarks>
        /// Required.
        /// </remarks>
        [XmlElement("availability")]
        public AvailabilityQueryParamas Params { get; set; }
    }

    public sealed class AvailabilityQueryParamas
    {
        /// <summary>
        /// Gets or sets the departure city or airport.
        /// </summary>
        /// <remarks>
        /// Required.
        /// The string must contain 3 letters.
        /// </remarks>
        [XmlElement("departure")]
        public String Departure { get; set; }

        /// <summary>
        /// Gets or sets the arrival city or airport.
        /// </summary>
        /// <remarks>
        /// Required.
        /// The string must contain 3 letters.
        /// </remarks>
        [XmlElement("arrival")]
        public String Arrival { get; set; }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is DD.MM.YY.
        /// </remarks>
        [XmlIgnore]
        public DateTime? Date { get; set; }

        /// <summary>
        /// USE Date instead.
        /// </summary>
        [XmlElement("date")]
        public String ProxyDate 
        {
            get
            {
                return (Date.HasValue) ? Date.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                Date = DateTime.ParseExact(value, "dd.MM.yy", null);
            }
        }

        /// <summary>
        /// Gets or sets the aviacompany.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The string must contain 3 letters.
        /// </remarks>
        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The string contain 5 letters.
        /// </remarks>
        [XmlElement("flight")]
        public String FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the base class.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The string must contain 1 letter.
        /// </remarks>
        [XmlElement("baseclass")]
        public String BaseClass { get; set; }

        /// <summary>
        /// Gets or sets the subclass.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The string must contain 1 letter.
        /// </remarks>
        [XmlElement("subclass")]
        public List<String> SubClasses { get; set; }

        /// <summary>
        /// Gets or sets the minimal departure time.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is HH24MI.
        /// </remarks>
        [XmlIgnore]
        public TimeSpan? TimeFrom { get; set; }

        /// <summary>
        /// USE TimeFrom instead.
        /// </summary>
        [XmlElement("time_from")]
        public String ProxyTimeFrom
        {
            get
            {
                return (TimeFrom.HasValue) ? TimeFrom.Value.ToString("hhmm") : null;
            }
            set
            {
                TimeFrom = TimeSpan.ParseExact(value, "hhmm", null);
            }
        }

        /// <summary>
        /// Gets or sets the maximal departure time.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is HH24MI.
        /// </remarks>
        [XmlIgnore]
        public TimeSpan? TimeTill { get; set; }

        /// <summary>
        /// USE TimeTill instead.
        /// </summary>
        [XmlElement("time_till")]
        public String ProxyTimeTill
        {
            get
            {
                return (TimeTill.HasValue) ? TimeTill.Value.ToString("hhmm") : null;
            }
            set
            {
                TimeTill = TimeSpan.ParseExact(value, "hhmm", null);
            }
        }

        /// <summary>
        /// Gets or sets the request params.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        [XmlElement("request_params")]
        public AvailabilityRequestParams RequestParams { get; set; }

        /// <summary>
        /// Gets or set the answer params.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        [XmlElement("answer_params")]
        public AvailabilityAnswerParams AnswerParams { get; set; }
    }

    public sealed class AvailabilityAnswerParams
    {
        /// <summary>
        /// Gets or sets the marker to show the flight time info.
        /// </summary>
        [XmlElement("show_flighttime")]
        public Boolean ShowFlightTime { get; set; }

        /// <summary>
        /// Gets or sets the marker tos show the base class for all flight subclasses.
        /// </summary>
        [XmlElement("show_baseclass")]
        public Boolean ShowBaseClass { get; set; }

        /// <summary>
        /// Gets or sets the date of when getting available places.
        /// </summary>
        [XmlElement("return_date")]
        public Boolean ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the marker to show a city or an airport in the response.
        /// </summary>
        [XmlElement("mark_cityport")]
        public Boolean MarkCityPort { get; set; }

        /// <summary>
        /// Gets or sets the availability for issueing an e-ticket.
        /// </summary>
        [XmlElement("show_et")]
        public Boolean ShowEt { get; set; }
    }

    public sealed class AvailabilityRequestParams
    {
        /// <summary>
        /// Gets or sets the joint type for a flight.
        /// </summary>
        [XmlElement("joint_type")]
        public JointType JointType { get; set; }

        /// <summary>
        /// Gets or sets restriction in a Tch selling session.
        /// </summary>
        [XmlElement("check_tch_restrictions")]
        public Boolean CheckTchRestrictions { get; set; }
    }

    /// <summary>
    /// Joint types for a flight.
    /// </summary>
    public enum JointType
    {
        /// <summary>
        /// All joints.
        /// </summary>
        [XmlEnum("jtAll")]
        All,

        /// <summary>
        /// No joints.
        /// </summary>
        [XmlEnum("jtNone")]
        None,

        /// <summary>
        /// All joints for the current avia company.
        /// </summary>
        [XmlEnum("jtAwk")]
        Awk,

        /// <summary>
        /// All joints according to the M2 contract.
        /// </summary>
        [XmlEnum("jtM2")]
        M2,

        /// <summary>
        /// Joints by direct(interline) contracts.
        /// </summary>
        [XmlEnum("jtInterline")]
        Interline,
    }
}
