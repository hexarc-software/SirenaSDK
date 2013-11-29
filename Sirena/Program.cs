using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Collections.Generic;

using NLog;

using BookingEngine.SirenaConnector.Properties;
using BookingEngine.SirenaConnector.Dto.Responses;
using BookingEngine.SirenaConnector.Dto.Requests;

namespace BookingEngine.SirenaConnector
{
    class Program
    {
        static void Main(String[] args)
        {
            //var client = new SirenaClient();
            //client.Connect();

            //var request = new AvailabilityRequest();
            //request.Query = new AvailabilityQuery();
            //request.Query.QueryParams = new AvailabilityQueryParamas();
            //request.Query.QueryParams.Departure = "NSK";
            //request.Query.QueryParams.Arrival = "MJZ";
            //request.Query.QueryParams.Date = new DateTime(2018, 1, 10);
            //request.Query.QueryParams.AnswerParams = new AvailabilityAnswerParams();
            //request.Query.QueryParams.AnswerParams.ShowBaseClass = true;
            //request.Query.QueryParams.RequestParams = new AvailabilityRequestParams();
            ////request.Query.QueryParams.RequestParams.JointType = JointType.Interline;

            //var response = client.SendRequest<AvailabilityRequest, AvailabilityResponse>(request, ConnectionMode.Plain);
            //File.WriteAllText("text.xml", SerializationHelper.Serialize(response));
            //var response2 = client.SendRequest(SerializationHelper.Serialize(request), ConnectionMode.Plain);
            //File.WriteAllText("text2.xml", response2);

            //var client = new SirenaClient(SirenaClientSettings.ZctsSettings);
            //client.Connect();

            //var request = new FaresRequest();
            //request.Query = new FaresQuery();
            //request.Query.QueryParams = new FaresQueryParams();
            //request.Query.QueryParams.Departure = "MOW";
            //request.Query.QueryParams.Arrival = "LON";
            //request.Query.QueryParams.DepartureTime = new DateTime(2013, 10, 13);

            //var response = client.SendRequest<FaresRequest, FaresResponse>(request, ConnectionMode.Symmetric);
            //File.WriteAllText("text.xml", SerializationHelper.Serialize(response));
            //var response2 = client.SendRequest(SerializationHelper.Serialize(request), ConnectionMode.Plain);
            //File.WriteAllText("text2.xml", response2);

            //var fareremarkRequest = new FareremarkRequest();
            //fareremarkRequest.Query = new FareremarkQuery();
            //fareremarkRequest.Query.QueryParams = new FareremarkQueryParams();
            //fareremarkRequest.Query.QueryParams.RequestParams = new FareremarkRequestParams();
            //fareremarkRequest.Query.QueryParams.FareName = response.Answer.FareCollection.Fares[0].Name;
            //fareremarkRequest.Query.QueryParams.RequestParams.Upt = response.Answer.FareCollection.Fares[0].Upt;
            //fareremarkRequest.Query.QueryParams.AnswerParams = new FareremarkAnswerParams();
            //fareremarkRequest.Query.QueryParams.AnswerParams.Language = "ru";

            //var fareremarkResponse = client.SendRequest<FareremarkRequest, FareremarkResponse>(fareremarkRequest);
            //var fareremarkResponse1 = client.SendRequest(SerializationHelper.Serialize(fareremarkRequest));
            //Console.WriteLine(fareremarkResponse1);
            //Console.WriteLine(SerializationHelper.Serialize(fareremarkResponse));
        }
    }
}