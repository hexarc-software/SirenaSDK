using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class ScheduleRequest : DtoRequest
    {
        [XmlElement("query")]
        public ScheduleQuery Query { get; set; }
    }

    public sealed class ScheduleQuery
    {
        [XmlElement("schedule")]
        public ScheduleQueryParams Params { get; set; }
    }

    public sealed class ScheduleQueryParams
    {
        [XmlElement("departure")]
        public String Departure { get; set; }

        [XmlElement("arrival")]
        public String Arrival { get; set; }

        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets or sets the departure or period start date.
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
        /// Gets or sets the period finish date.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is DD.MM.YY.
        /// </remarks>
        [XmlIgnore]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// USE Date instead.
        /// </summary>
        [XmlElement("date2")]
        public String ProxyEndDate
        {
            get
            {
                return (EndDate.HasValue) ? EndDate.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                EndDate = DateTime.ParseExact(value, "dd.MM.yy", null);
            }
        }

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
        /// Gets or sets the flag to search only direct flights.
        /// </summary>
        [XmlElement("direct")]
        public Boolean OnlyDirect { get; set; }

        [XmlElement("request_params")]
        public ScheduleRequestParams RequestParams { get; set; }

        [XmlElement("answer_params")]
        public ScheduleAnswerParams AnswerParams { get; set; }
    }

    public sealed class ScheduleRequestParams
    {
        /// <summary>
        /// Gets or sets the flag to show connected flights
        /// for a single company.
        /// </summary>
        [XmlElement("only_m2_joints")]
        public Boolean OnlyM2Joints { get; set; }
    }

    public sealed class ScheduleAnswerParams
    {
        /// <summary>
        /// Gets or sets the marker to show the flight time info.
        /// </summary>
        [XmlElement("show_flighttime")]
        public Boolean ShowFlightTime { get; set; }

        /// <summary>
        /// Gets or sets the full date (dd.MM.yyyy) format in answers.
        /// </summary>
        [XmlElement("full_date")]
        public Boolean FullDate { get; set; }

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
}
