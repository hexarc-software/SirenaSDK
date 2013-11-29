using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class ScheduleResponse : DtoResponse
    {
        /// <summary>
        /// Gets the response answer.
        /// </summary>
        [XmlElement("answer")]
        public ScheduleAsnwer Answer { get; set; }
    }

    public sealed class ScheduleAsnwer
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

        /// <summary>
        /// Gets the answer body.
        /// </summary>
        [XmlElement("schedule")]
        public ScheduleAnswerBody Body { get; set; }
    }

    public sealed class ScheduleAnswerBody
    {
        /// <summary>
        /// Gets the departure city.
        /// </summary>
        [XmlAttribute("departure")]
        public String Departure { get; set; }

        /// <summary>
        /// Gets the arrival city.
        /// </summary>
        [XmlAttribute("arrival")]
        public String Arrival { get; set; }

        /// <summary>
        /// Gets the date of the request departure time.
        /// </summary>
        /// <remarks>
        /// The date format is dd.MM.yyyy.
        /// </remarks>
        [XmlIgnore]
        public DateTime? Date { get; set; }

        /// <summary>
        /// USE Date instead.
        /// </summary>
        [XmlAttribute("date")]
        public String ProxyDate
        {
            get
            {
                return (Date.HasValue) ? Date.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    var date = default(DateTime);
                    if (DateTime.TryParseExact(value, "dd.MM.yy", null, DateTimeStyles.None, out date))
                    {
                        Date = date;
                        return;
                    }
                    if (DateTime.TryParseExact(value, "dd.MM.yyyy", null, DateTimeStyles.None, out date))
                    {
                        Date = date;
                        return;
                    }
                }
            }
        }

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

        /// <summary>
        /// Gets the single segment flights.
        /// </summary>
        [XmlElement("flight")]
        public ScheduleFlight[] Flights { get; set; }

        /// <summary>
        /// Gets the multi segment flights.
        /// </summary>
        [XmlElement("flights")]
        public ScheduleSegmentedFlight[] MultiSegmentFlights { get; set; }
    }

    public sealed class ScheduleSegmentedFlight
    {
        /// <summary>
        /// Gets the flight segments.
        /// </summary>
        [XmlElement("flight")]
        public ScheduleFlight[] FlightSegments { get; set; }
    }

    public sealed class ScheduleFlight
    {
        /// <summary>
        /// Gets the air company name.
        /// </summary>
        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets flight number.
        /// </summary>
        [XmlElement("num")]
        public String FlightNumber { get; set; }

        /// <summary>
        /// Gets the departure city.
        /// </summary>
        [XmlElement("origin")]
        public String Original { get; set; }

        /// <summary>
        /// Gets the departure city terminal.
        /// </summary>
        [XmlElement("orig_term")]
        public String OriginalTerminal { get; set; }

        /// <summary>
        /// Gets the destination city.
        /// </summary>
        [XmlElement("destination")]
        public String Destination { get; set; }

        /// <summary>
        /// Gets the destination city terminal.
        /// </summary>
        [XmlElement("dest_term")]
        public String DestinationTerminal { get; set; }

        /// <summary>
        /// Gets the departure time.
        /// </summary>
        [XmlElement("depttime")]
        public ScheduleFlightTime DepartureTime { get; set; }

        /// <summary>
        /// Gets the arrival time.
        /// </summary>
        [XmlElement("arrvtime")]
        public ScheduleFlightTime ArrivalTime { get; set; }

        /// <summary>
        /// Gets the period info for the schedule.
        /// </summary>
        [XmlElement("period")]
        public ScheduleFlightPeriod Period { get; set; }

        /// <summary>
        /// Gets the airplane code.
        /// </summary>
        [XmlElement("airplane")]
        public String Airplane { get; set; }

        /// <summary>
        /// Gets the flight summary.
        /// </summary>
        [XmlElement("classes")]
        public ScheduleFlightClassInfo ClassInfo { get; set; }

        /// <summary>
        /// Gets the flight time.
        /// </summary>
        /// <remarks>
        /// Only hours and minutes will be used.
        /// </remarks>
        [XmlIgnore]
        public TimeSpan? FlightTime { get; set; }

        /// <summary>
        /// USE FlightTime instead.
        /// </summary>
        [XmlElement("flightTime")]
        public String ProxyFlightTime
        {
            get
            {
                return (FlightTime.HasValue) ? FlightTime.Value.ToString("hh':'mm") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    FlightTime = TimeSpan.ParseExact(value, "g", null);
                }
            }
        }

        /// <summary>
        /// Gets the flag indicates e-ticketing is possible.
        /// </summary>
        [XmlIgnore]
        public Boolean? IsEticketPossible { get; set; }

        /// <summary>
        /// USE IsEticketPossible instead.
        /// </summary>
        [XmlElement("et_possible")]
        public String ProxyIsETicketPossible
        {
            get
            {
                return (IsEticketPossible.HasValue) ? IsEticketPossible.ToString().ToLower() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    IsEticketPossible = Boolean.Parse(value);
                }
            }
        }
    }

    public sealed class ScheduleFlightPeriod
    {
        /// <summary>
        /// Gets the period begin date.
        /// </summary>
        [XmlIgnore]
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// USE BeginDate instead.
        /// </summary>
        [XmlAttribute("begin")]
        public String ProxyBeginDate
        {
            get
            {
                return BeginDate.ToString("dd.MM.yy");
            }
            set
            {
                var date = default(DateTime);
                if (DateTime.TryParseExact(value, "dd.MM.yy", null, DateTimeStyles.None, out date))
                {
                    BeginDate = date;
                    return;
                }
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", null, DateTimeStyles.None, out date))
                {
                    BeginDate = date;
                    return;
                }
            }
        }

        /// <summary>
        /// Gets the period end date.
        /// </summary>
        [XmlIgnore]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// USE EndDate instead.
        /// </summary>
        [XmlAttribute("end")]
        public String ProxyEndDate
        {
            get
            {
                return EndDate.ToString("dd.MM.yy");
            }
            set
            {
                var date = default(DateTime);
                if (DateTime.TryParseExact(value, "dd.MM.yy", null, DateTimeStyles.None, out date))
                {
                    EndDate = date;
                    return;
                }
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", null, DateTimeStyles.None, out date))
                {
                    EndDate = date;
                    return;
                }
            }
        }

        /// <summary>
        /// Gets the week days.
        /// </summary>
        [XmlAttribute("days")]
        public String Days { get; set; }
    }

    public sealed class ScheduleFlightClassInfo
    {
        /// <summary>
        /// Gets the economy class availablity.
        /// </summary>
        /// <remarks>
        /// 1 is available.
        /// </remarks>
        [XmlAttribute("econom")]
        public Int32 EconomyAvailable { get; set; }

        /// <summary>
        /// Gets the business class availablity.
        /// </summary>
        /// <remarks>
        /// 1 is available.
        /// </remarks>
        [XmlAttribute("business")]
        public Int32 BussinessAvailable { get; set; }

        /// <summary>
        /// Gets the first class availablity.
        /// </summary>
        /// <remarks>
        /// 1 is available.
        /// </remarks>
        [XmlAttribute("first")]
        public Int32 FirstAvailable { get; set; }
    }

    public sealed class ScheduleFlightTime
    {
        /// <summary>
        /// Gets the shift of the initial departure date.
        /// </summary>
        /// <remarks>
        /// Can be negative.
        /// </remarks>
        [XmlIgnore]
        public Int32? DayShift { get; set; }

        /// <summary>
        /// USE DayShift instead.
        /// </summary>
        [XmlAttribute("dayshift")]
        public String ProxyDayShift
        {
            get
            {
                return (DayShift.HasValue) ? DayShift.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    DayShift = Int32.Parse(value);
                }
            }
        }

        /// <summary>
        /// USE Time instead.
        /// </summary>
        [XmlText]
        public String ProxyTime
        {
            get
            {
                return (Time.HasValue) ? Time.Value.ToString("hh':'mm") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Time = TimeSpan.ParseExact(value, "g", null);
                }
            }
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <remarks>
        /// Only hours and minutes will be used.
        /// </remarks>
        [XmlIgnore]
        public TimeSpan? Time { get; set; }
    }

}
