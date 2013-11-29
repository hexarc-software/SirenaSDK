using System;
using System.Globalization;
using System.Xml.Serialization;

using Sirena.Helpers;

namespace Sirena
{
    [XmlRoot("sirena")]
    public sealed class BookingResponse : DtoResponse
    {
        [XmlElement("answer")]
        public BookingAnswer Answer { get; set; }
    }

    /// <summary>
    /// Represents the booking response answer.
    /// </summary>
    public sealed class BookingAnswer
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

        [XmlElement("booking")]
        public BookingAnswerBody Body { get; set; }
    }

    public sealed class BookingAnswerBody
    {
        [XmlAttribute("regnum")]
        public String RegistrationNumber { get; set; }

        [XmlAttribute("agency")]
        public String Agency { get; set; }

        [XmlElement("pnr")]
        public BookingPassengerNameRecord PassengerNameRecord { get; set; }

        [XmlElement("contacts")]
        public BookingResponseContacts Contacts { get; set; }

        [XmlIgnore]
        public Boolean? LatinRegistration { get; set; }

        [XmlElement("latin_registration")]
        public String ProxyLatinRegistration
        {
            get
            {
                return (LatinRegistration.HasValue) ? LatinRegistration.Value.ToString().ToLower() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    LatinRegistration = Boolean.Parse(value);
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
    }

    public sealed class BookingPassengerNameRecord
    {
        [XmlElement("regnum")]
        public String RegistrationNumber { get; set; }

        [XmlIgnore]
        public DateTime TimeLimit { get; set; }

        [XmlElement("timelimit")]
        public String ProxyTimeLimit
        {
            get
            {
                return TimeLimit.ToString("dd.MM.yy HH:mm");
            }
            set
            {
                TimeLimit = DateTime.ParseExact(value, "dd.MM.yy HH:mm", null);
            }
        }

        [XmlIgnore]
        public DateTime UtcTimeLimit { get; set; }

        [XmlElement("utc_timelimit")]
        public String ProxyUtcTimeLimit
        {
            get
            {
                return UtcTimeLimit.ToString("HH:mm dd.MM.yyyy");
            }
            set
            {
                UtcTimeLimit = DateTime.ParseExact(value, "HH:mm dd.MM.yyyy", null);
            }
        }

        [XmlArray("passengers")]
        [XmlArrayItem("passenger")]
        public BookingResponsePassenger[] Passengers { get; set; }

        [XmlArray("segments")]
        [XmlArrayItem("segment")]
        public BookingResponseSegment[] Segments { get; set; }

        [XmlElement("prices")]
        public BookingPrices Prices { get; set; }
    }

    public sealed class BookingResponseContacts
    {
        [XmlElement("email")]
        public String[] Emails { get; set; }

        [XmlElement("contact")]
        public BookingContact[] ContactItems { get; set; }
    }

    public sealed class BookingResponsePassenger
    {
        [XmlIgnore]
        public Int32? Id { get; set; }

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

        [XmlIgnore]
        public Boolean? IsLeader { get; set; }

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

        [XmlElement("surname")]
        public String Surname { get; set; }

        [XmlElement("name")]
        public String Name { get; set; }

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
        /// Gets the passenger birth date.
        /// </summary>
        [XmlIgnore]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// USE BirthDate instead.
        /// </summary>
        [XmlElement("birthdate")]
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
        /// Gets the passenger age.
        /// </summary>
        [XmlIgnore]
        public Int32? Age { get; set; }

        /// <summary>
        /// USE Age instead.
        /// </summary>
        [XmlElement("age")]
        public String ProxyAge
        {
            get
            {
                return (Age.HasValue) ? Age.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Age = Int32.Parse(value);
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
        /// Gets the passenger nationality.
        /// </summary>
        [XmlElement("nationality")]
        public String Nationality { get; set; }

        /// <summary>
        /// Gets the discount document type.
        /// </summary>
        [XmlElement("doccode_disc")]
        public String DiscountDocumentType { get; set; }

        /// <summary>
        /// Gets the discount document number.
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
        /// Gets the passenger contacts.
        /// </summary>
        [XmlElement("contacts")]
        public BookingResponsePassengerContacts Contacts { get; set; }
    }

    public sealed class BookingResponsePassengerContacts
    {
        [XmlElement("phone")]
        public BookingContact[] Phones { get; set; }

        [XmlElement("contact")]
        public BookingContact[] ContactItems { get; set; }

        [XmlElement("email")]
        public String Email { get; set; }
    }

    /// <summary>
    /// Represents the booking segment.
    /// </summary>
    public sealed class BookingResponseSegment
    {
        [XmlIgnore]
        public Int32? Id { get; set; }

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

        [XmlElement("company")]
        public String Company { get; set; }

        [XmlElement("flight")]
        public String FlightNumber { get; set; }

        [XmlElement("airplane")]
        public String Airplane { get; set; }

        [XmlElement("class")]
        public String Class { get; set; }

        [XmlElement("subclass")]
        public String SubClass { get; set; }

        [XmlElement("seatcount")]
        public Int32 SeatCount { get; set; }

        [XmlElement("departure")]
        public BookingResponseSegmentPoint Departure { get; set; }

        [XmlElement("arrival")]
        public BookingResponseSegmentPoint Arrival { get; set; }

        /// <summary>
        /// Gets the segment status.
        /// </summary>
        [XmlIgnore]
        public BookingSegmentStatus Status { get; set; }

        /// <summary>
        /// USE Status instead.
        /// </summary>
        [XmlElement("status")]
        public String ProxyStatus
        {
            get
            {
                return EnumHelper.GetXmlEnumName(Status);
            }
            set
            {
                Status = (BookingSegmentStatus)EnumHelper.ParseXmlEnumName(typeof(BookingSegmentStatus), value);
            }
        }

    }

    /// <summary>
    /// Represents the booking segment point.
    /// </summary>
    public sealed class BookingResponseSegmentPoint
    {
        [XmlElement("city")]
        public String City { get; set; }

        [XmlElement("airport")]
        public String Airport { get; set; }

        [XmlElement("terminal")]
        public String Terminal { get; set; }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("date")]
        public String DateProxy
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

        [XmlIgnore]
        public TimeSpan Time { get; set; }

        [XmlElement("time")]
        public String ProxyTime
        {
            get
            {
                return Time.ToString("hh':'mm");
            }
            set
            {
                Time = TimeSpan.ParseExact(value, "hh':'mm", null);
            }
        }
    }

    /// <summary>
    /// Represents the booking price collection.
    /// </summary>
    public sealed class BookingPrices
    {
        [XmlAttribute("tick_ser")]
        public String TicketSeries { get; set; }

        [XmlAttribute("fop")]
        public String Fop { get; set; }

        [XmlElement("price")]
        public BookingPrice[] Prices { get; set; }

        [XmlElement("variant_total")]
        public BookingCurrencyValue VariantTotal { get; set; }
    }

    /// <summary>
    /// Represents the booking price info.
    /// </summary>
    public sealed class BookingPrice
    {
        [XmlIgnore]
        public Int32? SegmentId { get; set; }

        [XmlAttribute("segment-id")]
        public String ProxySegmentId
        {
            get
            {
                return (SegmentId.HasValue) ? SegmentId.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    SegmentId = Int32.Parse(value);
                }
            }
        }

        [XmlIgnore]
        public Int32? PassengerId { get; set; }

        [XmlAttribute("passenger-id")]
        public String ProxyPassengerId
        {
            get
            {
                return (PassengerId.HasValue) ? PassengerId.Value.ToString() : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    PassengerId = Int32.Parse(value);
                }
            }
        }

        [XmlAttribute("accode")]
        public String Accode { get; set; }

        [XmlElement("fare")]
        public BookingPriceFare Fare { get; set; }

        [XmlArray("taxes")]
        [XmlArrayItem("tax")]
        public BookingPriceTax[] Taxes { get; set; }
    }

    /// <summary>
    /// Represents the fare info.
    /// </summary>
    public sealed class BookingPriceFare
    {
        /// <summary>
        /// Gets the fare expiration date.
        /// </summary>
        [XmlIgnore]
        public DateTime? FareExpirationDate { get; set; }
        
        /// <summary>
        /// USE FareExpirationDate instead.
        /// </summary>
        [XmlAttribute("fare_expdate")]
        public String ProxyFareExpirationDate
        {
            get
            {
                return (FareExpirationDate.HasValue) ? FareExpirationDate.Value.ToString("yyyy-MM-dd hh:mm") : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    FareExpirationDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", null);
                }
            }
        }

        /// <summary>
        /// Gets the fare code info.
        /// </summary>
        [XmlElement("code")]
        public BookingPriceCode Code { get; set; }

        /// <summary>
        /// Gets the currency value.
        /// </summary>
        [XmlElement("value")]
        public BookingCurrencyValue CurrencyValue { get; set; }
    }

    /// <summary>
    /// Represents the tax info.
    /// </summary>
    public sealed class BookingPriceTax
    {
        /// <summary>
        /// Gets the tax owner.
        /// </summary>
        [XmlIgnore]
        public BookingTaxOwner? Owner { get; set; }

        /// <summary>
        /// USE Owner instead.
        /// </summary>
        [XmlAttribute("owner")]
        public String ProxyOwnerType
        {
            get
            {
                return (Owner.HasValue) ? EnumHelper.GetXmlEnumName(Owner.Value) : null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Owner = (BookingTaxOwner)EnumHelper.ParseXmlEnumName(typeof(BookingTaxOwner), value.ToString());
                }
            }
        }

        /// <summary>
        /// Gets the tax code info.
        /// </summary>
        [XmlElement("code")]
        public BookingPriceCode Code { get; set; }

        /// <summary>
        /// Gets the tax currency value.
        /// </summary>
        [XmlElement("value")]
        public BookingCurrencyValue CurrencyValue { get; set; }
    }

    /// <summary>
    /// Represents the currency value.
    /// </summary>
    public sealed class BookingCurrencyValue
    {
        /// <summary>
        /// Gets the currency type.
        /// </summary>
        [XmlAttribute("currency")]
        public String Currency { get; set; }

        /// <summary>
        /// Gets the currency value.
        /// </summary>
        [XmlText]
        public Single Value { get; set; }
    }

    /// <summary>
    /// Represents the code infomation about taxes and fares.
    /// </summary>
    public sealed class BookingPriceCode
    {
        /// <summary>
        /// Gets the base code.
        /// </summary>
        [XmlAttribute("base_code")]
        public String BaseCode { get; set; }

        /// <summary>
        /// Gets the code value.
        /// </summary>
        [XmlText]
        public String Value { get; set; }
    }
    
    /// <summary>
    /// Contains tax owners.
    /// </summary>
    public enum BookingTaxOwner
    {
        /// <summary>
        /// Tax owner is aircompany.
        /// </summary>
        [XmlEnum("aircompany")]
        Aircompany,

        /// <summary>
        /// Tax owner is agency.
        /// </summary>
        [XmlEnum("agency")]
        Agency,

        /// <summary>
        /// Tax owner is neutral.
        /// </summary>
        [XmlEnum("neutral")]
        Neutral
    }

    /// <summary>
    /// Contains booking segment statuses.
    /// </summary>
    public enum BookingSegmentStatus
    {
        /// <summary>
        /// The segment is in a waitlist.
        /// </summary>
        [XmlEnum("waitlist")]
        Waitlist,

        /// <summary>
        /// The segment is refused.
        /// </summary>
        [XmlEnum("refused")]
        Refused,

        /// <summary>
        /// The segment is confirmed.
        /// </summary>
        [XmlEnum("confirmed")]
        Confirmed,

        /// <summary>
        /// The segment is uncofirmed.
        /// </summary>
        [XmlEnum("uncofirmed")]
        Uncofirmed,
    }
}
