using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class FaresRequest : DtoRequest
    {
        [XmlElement("query")]
        public FaresQuery Query { get; set;}
    }

    public sealed class FaresQuery
    {
        [XmlElement("fares")]
        public FaresQueryParams Params { get; set; }
    }

    public sealed class FaresQueryParams
    {
        /// <summary>
        /// Gets or sets the departure city.
        /// </summary>
        [XmlElement("departure")]
        public String Departure { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        [XmlElement("arrival")]
        public String Arrival { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [XmlIgnore]
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// USE DepartureTime instead.
        /// </summary>
        [XmlElement("deptdate")]
        public String ProxyDepartureTime
        {
            get
            {
                return (DepartureTime.HasValue) ? DepartureTime.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    DepartureTime = DateTime.ParseExact(value, "dd.MM.yy", null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        [XmlIgnore]
        public DateTime? BookDate { get; set; }

        /// <summary>
        /// USE BookDate instead.
        /// </summary>
        [XmlElement("bookdate")]
        public String ProxyBookDate
        {
            get
            {
                return (BookDate.HasValue) ? BookDate.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    BookDate = DateTime.ParseExact(value, "dd.MM.yy", null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        [XmlElement("flight")]
        public String FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the flight subclasses.
        /// </summary>
        [XmlElement("subclass")]
        public List<String> SubClasses { get; set; }

        /// <summary>
        /// Gets or sets the flight base class.
        /// </summary>
        [XmlElement("baseclass")]
        public String BaseClass { get; set; }

        /// <summary>
        /// Gets or sets the passenger category.
        /// </summary>
        [XmlElement("passenger")]
        public String PassengerCategory { get; set; }

        /// <summary>
        /// Gets or sets the request params.
        /// </summary>
        [XmlElement("request_params")]
        public FaresRequestParams RequestParams { get; set; }
    }

    public sealed class FaresRequestParams
    {
        /// <summary>
        /// Gets or sets the ticket series.
        /// </summary>
        [XmlElement("tick_ser")]
        public String TicketSeries { get; set; }

        /// <summary>
        /// Gets or sets the flag to show special fares.
        /// </summary>
        [XmlElement("tripflag")]
        public Boolean TripFlag { get; set; }
    }
}
