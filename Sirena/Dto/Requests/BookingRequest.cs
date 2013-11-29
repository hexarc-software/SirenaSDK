using System;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;

using Sirena.Helpers;

namespace Sirena
{
    /// <summary>
    /// Represents the Sirena booking request.
    /// </summary>
    [XmlRoot("sirena")]
    public sealed class BookingRequest : DtoRequest
    {
        /// <summary>
        /// Gets or sets the query data.
        /// </summary>
        /// <remarks>
        /// Required.
        /// </remarks>
        [XmlElement("query")]
        public BookingQuery Query { get; set; }
    }

    /// <summary>
    /// Represents the query data that used in
    /// the Sirena booking request.
    /// </summary>
    public sealed class BookingQuery
    {
        /// <summary>
        /// Gets or sets the query params.
        /// </summary>
        /// <remarks>
        /// Required.
        /// </remarks>
        [XmlElement("booking")]
        public BookingQueryParams Params { get; set; }
    }

    /// <summary>
    /// Represents the query params that used in
    /// the Sirena booking request.
    /// </summary>
    public sealed class BookingQueryParams
    {
        /// <summary>
        /// Gets or sets the flight segments.
        /// </summary>
        [XmlElement("segment")]
        public List<BookingRequestSegment> Segments { get; set; }

        /// <summary>
        /// Gets or sets the passengers info.
        /// </summary>
        [XmlElement("passenger")]
        public List<BookingRequestPassenger> Passengers { get; set; }

        /// <summary>
        /// Gets or sets the general contacts info.
        /// </summary>
        [XmlElement("contacts")]
        public BookingRequestContacts Contacts { get; set; }

        /// <summary>
        /// Gets or set the answer params.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        [XmlElement("answer_params")]
        public BookingAnswerParams AnswerParams { get; set; }

        /// <summary>
        /// Gets or sets the request params.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        [XmlElement("request_params")]
        public BookingRequestParams RequestParams { get; set; }
    }

    /// <summary>
    /// Represents the booking asnwer params.
    /// </summary>
    public sealed class BookingAnswerParams
    {
        /// <summary>
        /// Gets or sets the flag to show the airplane type.
        /// </summary>
        [XmlElement("show_tts")]
        public Boolean ShowTts { get; set; }

        /// <summary>
        /// Gets or sets the flag to show the Upt info.
        /// </summary>
        [XmlElement("show_upt_rec")]
        public Boolean ShowUptRecord { get; set; }

        /// <summary>
        /// Gets or sets the flag to show remarks about passengers.
        /// </summary>
        [XmlElement("add_remarks")]
        public Boolean AddRemarks { get; set; }
    }

    /// <summary>
    /// Represents the booking request params.
    /// </summary>
    public sealed class BookingRequestParams
    {
        /// <summary>
        /// Gets or sets the language used in the response.
        /// </summary>
        [XmlElement("lang")]
        public String Language { get; set; }

        /// <summary>
        /// Gets or sets the ticket series to estimate the fare.
        /// </summary>
        [XmlElement("tick_ser")]
        public String TicketSeries { get; set; }

        /// <summary>
        /// Gets or sets the parcel agency
        /// </summary>
        /// <remarks>
        /// The value should contain 5 letters.
        /// </remarks>
        [XmlElement("parcel_agency")]
        public String ParcelAgency { get; set; }
    }

    /// <summary>
    /// Represents the booking request segment info.
    /// </summary>
    public sealed class BookingRequestSegment
    {
        /// <summary>
        /// Gets or sets the segment id.
        /// </summary>
        [XmlIgnore]
        public Int32? Id { get; set; }

        /// <summary>
        /// USE Id instead.
        /// </summary>
        [XmlAttribute("id")]
        public String ProxyId
        {
            get
            {
                return (Id.HasValue) ? Id.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Id = Int32.Parse(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the aviacompany.
        /// </summary>
        /// <remarks>
        /// Required.
        /// The string must contain 3 letters.
        /// </remarks>
        [XmlElement("company")]
        public String Company { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        /// <remarks>
        /// Required.
        /// The string contain 5 letters.
        /// </remarks>
        [XmlElement("num")]
        public String FlightNumber { get; set; }

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
        /// Required.
        /// The date format is DD.MM.YY.
        /// </remarks>
        [XmlIgnore]
        public DateTime Date { get; set; }

        /// <summary>
        /// USE Date instead.
        /// </summary>
        [XmlElement("date")]
        public String ProxyDate
        {
            get
            {
                return Date.ToString("dd.MM.yy");
            }
            set
            {
                Date = DateTime.ParseExact(value, "dd.MM.yy", null);
            }
        }

        /// <summary>
        /// Gets or sets the airplane.
        /// </summary>
        [XmlElement("airplane")]
        public String Airplane { get; set; }

        /// <summary>
        /// Gets or sets the flight class.
        /// </summary>
        /// <remarks>
        /// Required.
        /// The string must contain 1 letter.
        /// </remarks>
        [XmlElement("subclass")]
        public String SubClass { get; set; }
    }

    /// <summary>
    /// Represents the booking request passenger info.
    /// </summary>
    public sealed class BookingRequestPassenger
    {
        /// <summary>
        /// Gets the passenger id.
        /// </summary>
        [XmlIgnore]
        public Int32? Id { get; set; }

        /// <summary>
        /// USE Id instead.
        /// </summary>
        [XmlAttribute("id")]
        public String ProxyId
        {
            get
            {
                return (Id.HasValue) ? Id.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Id = Int32.Parse(value);
                }
            }
        }

        /// <summary>
        /// Gets the flag that indicated the passenger is a leader.
        /// </summary>
        [XmlIgnore]
        public Boolean? IsLeader { get; set; }

        /// <summary>
        /// USE IsLeader instead.
        /// </summary>
        [XmlAttribute("lead_pass")]
        public String ProxyIsLeader
        {
            get
            {
                return (IsLeader.HasValue) ? IsLeader.Value.ToString().ToLower() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    IsLeader = Boolean.Parse(value);
                }
            }
        }

        /// <summary>
        /// Gets the passenger surname.
        /// </summary>
        [XmlElement("surname")]
        public String Surname { get; set; }

        /// <summary>
        /// Gets the passenger name.
        /// </summary>
        [XmlElement("name")]
        public String Name { get; set; }

        /// <summary>
        /// Gets the passenger category.
        /// </summary>
        [XmlElement("category")]
        public String Category { get; set; }

        /// <summary>
        /// Gets or sets the passenger sex.
        /// </summary>
        [XmlIgnore]
        public BookingPassengerSex Sex { get; set; }

        /// <summary>
        /// USE Sex instead.
        /// </summary>
        [XmlElement("sex")]
        public String ProxySexType
        {
            get
            {
                return EnumHelper.GetXmlEnumName(Sex);
            }
            set
            {
                Sex = (BookingPassengerSex)EnumHelper.ParseXmlEnumName(typeof(BookingPassengerSex), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the passenger birthdate.
        /// </summary>
        [XmlIgnore]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// USE BirthDate instead.
        /// </summary>
        [XmlAttribute("age")]
        public String ProxyBirthDate
        {
            get
            {
                return BirthDate.ToString("dd.MM.yy");
            }
            set
            {
                var date = default(DateTime);
                if (DateTime.TryParseExact(value, "dd.MM.yy", null, DateTimeStyles.None, out date))
                {
                    BirthDate = date;
                    return;
                }
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", null, DateTimeStyles.None, out date))
                {
                    BirthDate = date;
                    return;
                }
            }
        }

        /// <summary>
        /// Gets or sets the document type.
        /// </summary>
        /// <remarks>
        /// Possible values:
        /// "SR" - birth certificated.
        /// "PS" - russian passport.
        /// "NP" - foreign passport.
        /// </remarks>
        [XmlElement("doccode")]
        public String DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        [XmlElement("doc")]
        public String DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the document expiration date.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is DD.MM.YY.
        /// </remarks>
        [XmlIgnore]
        public DateTime? DocumentExpirationDate { get; set; }

        /// <summary>
        /// USE DocumentExpirationDate instead.
        /// </summary>
        [XmlElement("pspexpire")]
        public String ProxyDocumentExpirationDate
        {
            get
            {
                return DocumentExpirationDate.HasValue ? DocumentExpirationDate.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    DocumentExpirationDate = DateTime.ParseExact(value, "dd.MM.yy", null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the passenger nationality.
        /// </summary>
        [XmlElement("nationality")]
        public String Nationality { get; set; }

        /// <summary>
        /// Gets or sets the discount document type.
        /// </summary>
        [XmlElement("doccode_disc")]
        public String DiscountDocumentType { get; set; }

        /// <summary>
        /// Gets or sets the discount document number.
        /// </summary>
        [XmlElement("doc_disc")]
        public String DiscountDocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the discount document expiration date.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// The date format is DD.MM.YY.
        /// </remarks>
        [XmlIgnore]
        public DateTime? DiscountDocumentExpirationDate { get; set; }

        /// <summary>
        /// USE DiscountDocumentExpirationDate instead.
        /// </summary>
        [XmlElement("pspexpire_disc")]
        public String ProxyDiscountDocumentExpirationDate
        {
            get
            {
                return DiscountDocumentExpirationDate.HasValue ? DiscountDocumentExpirationDate.Value.ToString("dd.MM.yy") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    DiscountDocumentExpirationDate = DateTime.ParseExact(value, "dd.MM.yy", null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the passenger phones.
        /// </summary>
        [XmlElement("phone")]
        public List<BookingContact> Phones { get; set; }

        /// <summary>
        /// Gets or sets the passenger contacts.
        /// </summary>
        [XmlElement("contact")]
        public List<BookingContact> Contacts { get; set; }
    }

    /// <summary>
    /// Represents the booking contact info.
    /// </summary>
    public sealed class BookingContact
    {
        /// <summary>
        /// Gets or sets the contact type.
        /// </summary>
        [XmlIgnore]
        public BookingContactType ContactType { get; set; }

        /// <summary>
        /// USE ContactType instead.
        /// </summary>
        [XmlAttribute("type")]
        public String ProxyContactType
        {
            get
            {
                return EnumHelper.GetXmlEnumName(ContactType);
            }
            set
            {
                ContactType = (BookingContactType)EnumHelper.ParseXmlEnumName(typeof(BookingContactType), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the contact comment.
        /// </summary>
        [XmlAttribute("comment")]
        public String Comment { get; set; }

        /// <summary>
        /// Gets or sets the contact value such as an email or phone.
        /// </summary>
        [XmlText]
        public String Value { get; set; }
    }

    /// <summary>
    /// Represents the booking request common contacts info.
    /// </summary>
    public sealed class BookingRequestContacts
    {
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [XmlElement("phone")]
        public BookingContact Phone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [XmlElement("email")]
        public String Email { get; set; }
    }

    /// <summary>
    /// Passenger genders.
    /// </summary>
    public enum BookingPassengerSex
    {
        [XmlEnum("female")]
        Female,

        [XmlEnum("male")]
        Male,
    }

    /// <summary>
    /// Contains contact types.
    /// </summary>
    public enum BookingContactType
    {
        [XmlEnum("agency")]
        Agency,

        [XmlEnum("mobile")]
        Mobile,

        [XmlEnum("home")]
        Home,

        [XmlEnum("work")]
        Work,

        [XmlEnum("fax")]
        Fax,

        [XmlEnum("hotel")]
        Hotel,

        [XmlEnum("email")]
        Email,
    }
}
