using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;

using NUnit.Framework;

using Sirena.Helpers;

namespace Sirena.Tests
{
    [TestFixture]
    public class FaresRequestTests
    {
        [Test]
        public void FaresRequest_Serialize_ShouldNotFail()
        {
            var request = new FaresRequest();
            request.Query = new FaresQuery();
            request.Query.Params = new FaresQueryParams();
            request.Query.Params.Departure = "MOW";
            request.Query.Params.Arrival = "LON";
            request.Query.Params.Company = "BT";

            var serializedRequest = SerializationHelper.Serialize(request);
            var xmlRequest = XDocument.Parse(serializedRequest);

            var fares = xmlRequest.Element("sirena").Element("query").Element("fares");

            Assert.True(fares.Element("departure").Value == "MOW");
            Assert.True(fares.Element("arrival").Value == "LON");
            Assert.True(fares.Element("deptdate") == null);
            Assert.True(fares.Element("bookdate") == null);
            Assert.True(fares.Element("company").Value == "BT");
            Assert.True(fares.Element("flight") == null);
            Assert.True(fares.Elements("subclass").Count() == 0);
            Assert.True(fares.Element("baseclass") == null);
            Assert.True(fares.Element("passenger") == null);
            Assert.True(fares.Element("request_params") == null);

        }

        [Test]
        public void FaresRequest_ResponseDeserialize_ShouldNotFail()
        {
            var rawResponse = File.ReadAllText("TestData/FaresResponse1.xml");
            var response = SerializationHelper.Deserialize<FaresResponse>(rawResponse);
        }
    }
}
