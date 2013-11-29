using NUnit.Framework;
using Sirena.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirena.Tests
{
    [TestFixture]
    public class ScheduleRequestTests
    {
        [Test]
        public void ScheduleRequest_DeserializeResponse_ShouldNotFail()
        {
            var responseText = 
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <sirena>
            <answer pult=""ТЕСТ01"">
            <schedule departure=""МОВ"" arrival=""СПТ"" date=""23.10.2010"">
            <flight>
            <company>7Б</company>
            <num>595</num>
            <et_possible>false</et_possible>
            <classes econom=""1"" business=""0"" first=""0""/>
            <origin type=""airport"" city=""МОВ"">ВНК</origin>
            <orig_term></orig_term>
            <destination type=""airport"" city=""СПТ"">ПЛК</destination>
            <dest_term></dest_term>
            <depttime>09:00</depttime>
            <arrvtime>10:00</arrvtime>
            <flightTime>1:00</flightTime>
            <airplane>737</airplane>
            </flight>
            <flight>
            <company>SU</company>
            <num>839</num>
            <et_possible>true</et_possible>
            <classes econom=""1"" business=""1"" first=""0""/>
            <origin type=""airport"" city=""МОВ"">ШРМ</origin>
            <orig_term>1</orig_term>
            <destination type=""airport"" city=""СПТ"">ПЛК</destination>
            <dest_term>1</dest_term>
            <depttime>08:15</depttime>
            <arrvtime>09:55</arrvtime>
            <flightTime>1:40</flightTime>
            <airplane>320</airplane>
            </flight>
            <flights>
            <flight>
            <company>OS</company>
            <num>606</num>
            <et_possible>false</et_possible>
            <classes econom=""1"" business=""1"" first=""0""/>
            <origin type=""airport"" city=""МОВ"">ДМД</origin>
            <orig_term></orig_term>
            <destination type=""airport"" city=""ВЕН"">VIE</destination>
            <dest_term></dest_term>
            <depttime>05:00</depttime>
            <arrvtime>06:05</arrvtime>
            <flightTime>3:05</flightTime>
            <airplane>319</airplane>
            </flight>
            <flight>
            <company>OS</company>
            <num>611</num>
            <et_possible>false</et_possible>
            <classes econom=""1"" business=""1"" first=""0""/>
            <origin type=""airport"" city=""ВЕН"">VIE</origin>
            <orig_term></orig_term>
            <destination type=""airport"" city=""СПТ"">ПЛК</destination>
            <dest_term>2</dest_term>
            <depttime>10:15</depttime>
            <arrvtime>15:00</arrvtime>
            <flightTime>2:45</flightTime>
            <airplane>100</airplane>
            </flight>
            </flights>
            </schedule>
            </answer>
            </sirena>";

            var response = SerializationHelper.Deserialize<ScheduleResponse>(responseText);
            var serializedResponse = SerializationHelper.Serialize(response);
            Console.WriteLine(serializedResponse);
        }
    }
}
