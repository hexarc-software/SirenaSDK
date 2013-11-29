using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using NUnit.Framework;

using Sirena.Helpers;

namespace Sirena.Tests
{
    [TestFixture]
    public class AvailabilityRequestTests
    {
        [Test]
        public void AvailabilityRequest_Serialize_OnlyRequiredFieldShouldBePresented()
        {
            // The required field are Departure and Arrival
            // other field should not produce any xml tags.
            var request = new AvailabilityRequest();
            request.Query = new AvailabilityQuery();
            request.Query.Params = new AvailabilityQueryParamas();
            request.Query.Params.Departure = "MOW";
            request.Query.Params.Arrival = "RIX";

            var rawRequest = SerializationHelper.Serialize(request);
            var xmlRequest = XDocument.Parse(rawRequest);

            var availability = xmlRequest.
                Element("sirena").
                Element("query").
                Element("availability");

            Assert.True(availability.Elements().Count() == 2);

            var departure = availability.Element("departure");
            var arrival = availability.Element("arrival");

            Assert.NotNull(departure);
            Assert.NotNull(arrival);
        }


        [Test]
        public void AvailabilityRequest_DeserializeResponse_ShouldContainErrorProperty()
        {
            var response = @"<?xml version=""1.0"" encoding=""utf-8""?>
            <sirena>
              <answer pult=""МОАР34"" msgid=""1014027036"" time=""18:44:51 16.06.2013"">
                <availability>
                  <error code=""33234"">Дата вылета в прошлом</error>
                </availability>
              </answer>
            </sirena>";

            var deserializedResponse = SerializationHelper.Deserialize<AvailabilityResponse>(response);
            Assert.True(deserializedResponse.Answer.Body.Error != null);
        }

        [Test]
        public void AvailabilityRequest_DeserializeResponse_ShouldNotThrowException()
        {
            var response = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <sirena>
            <answer pult=""ТЕСТ01"">
            <availability departure=""МОВ"" arrival=""ХБР"" class=""Э"" joint_type=""jtAll"">
            <flight>
            <company>Х8</company>
            <num>35</num>
            <origin>ДМД</origin>
            <destination>ХБР</destination>
            <depttime>19:15</depttime>
            <arrvtime dayshift=""1"">10:00</arrvtime>
            <airplane>Т24</airplane>
            <subclass count=""0"">Э</subclass>
            <summary first=""0"" business=""0"" econom=""0""/>
            </flight>
            <flight>
            <company>SU</company>
            <num>893</num>
            <origin>ШРМ</origin>
            <destination>ХБР</destination>
            <depttime>00:20</depttime>
            <arrvtime>16:50</arrvtime>
            <airplane>ИЛВ</airplane>
            <ilc>1</ilc>
            <status>У</status>
            <summary first=""0"" business=""0"" econom=""0""/>
            </flight>
            <flights>
            <flight>
            <company>УН</company>
            <num>115</num>
            <origin>ДМД</origin>
            <destination>ИКТ</destination>
            <depttime>18:30</depttime>
            <arrvtime dayshift=""1"">05:05</arrvtime>
            <airplane>762</airplane>
            <subclass count=""4"">К</subclass>
            <subclass count=""4"">Л</subclass>
            <subclass count=""-1"">М</subclass>
            <subclass count=""4"">Н</subclass>
            <subclass count=""-1"">Я</subclass>
            <summary first=""0"" business=""0"" econom=""1""/>
            </flight>
            <flight>
            <company>Х8</company>
            <num>364</num>
            <origin>ИКТ</origin>
            <destination>ХБР</destination>
            <depttime dayshift=""1"">08:00</depttime>
            <arrvtime dayshift=""1"">13:05</arrvtime>
            <airplane>ТУ5</airplane>
            <subclass count=""0"">Э</subclass>
            <summary first=""0"" business=""0"" econom=""0""/>
            </flight>
            </flights>
            </availability>
            </answer>
            </sirena>";

            var deserializedResponse = SerializationHelper.Deserialize<AvailabilityResponse>(response);
        }
    }
}
