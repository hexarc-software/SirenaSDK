using NUnit.Framework;
using Sirena.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirena.Tests
{
    [TestFixture]
    public class BookingRequestTests
    {
        [Test]
        public void BookingRequest_DeserializeResponse_ShouldNotFail()
        {
            var response = 
                @"<?xml version=""1.0""?>
                <sirena>
                <answer pult=""ИНЕТ01"">
                <booking regnum=""000Ц16"" agency=""01АГН"">
                <pnr>
                <regnum>000Ц16</regnum>
                <timelimit>18.09.05 15:51</timelimit>
                <utc_timelimit>11:51 18.09.2005</utc_timelimit>
                <passengers>
                <passenger id='12' lead_pass='true'>
                <name>ВАСИЛИЙ ПЕТРОВИЧ</name>
                <surname>ИВАНОВ</surname>
                <birthdate>01.06.1978</birthdate>
                <age>27</age>
                <doccode>ПС</doccode>
                <doc>67СБ1234</doc>
                <category rbm='0'>ААА</category>
                </passenger>
                </passengers>
                <segments>
                <segment id=""10"">
                <company>ПЛ</company>
                <flight>2431</flight>
                <class>Э</class>
                <seatcount>1</seatcount>
                <airplane>ТУ5</airplane>
                <departure>
                <city>МОВ</city>
                <airport>ШРМ</airport>
                <date>30.09.05</date>
                <time>19:00</time>
                </departure>
                <arrival>
                <city>СПТ</city>
                <airport>ПЛК</airport>
                <date>30.09.05</date>
                <time>21:00</time>
                </arrival>
                <status>confirmed</status>
                </segment>
                </segments>
                <prices tick_ser='6' fop='НА'>
                <price segment-id=""10"" passenger-id=""12"">
                <fare>
                <code>_</code>
                <value currency=""РУБ"">20.00</value>
                </fare>
                <taxes>
                <tax owner=""neutral"">
                <code>И</code>
                <value>70.00</value>
                </tax>
                <tax owner=""agency"">
                <code>ЙЖ</code>
                <value>123.00</value>
                </tax>
                <tax owner=""aircompany"">
                <code>А</code>
                <value>63.00</value>
                </tax>
                </taxes>
                </price>
                </prices>
                <contacts>
                <contact>(495)123-45-67</contact>
                </contacts>
                </pnr>
                </booking>
                </answer>
                </sirena>";

            var deserializedResponse = SerializationHelper.Deserialize<BookingResponse>(response);
            Console.WriteLine(SerializationHelper.Serialize(deserializedResponse));
        }

        [Test]
        public void BookingRequest_DeserializeRequest_ShouldNotFail()
        {
            var request =
                @"<?xml version=""1.0""?>
                <sirena>
                <query>
                <booking>
                <segment>
                <company>ПЛ</company>
                <num>2431</num>
                <departure>МОВ</departure>
                <arrival>СПТ</arrival>
                <date>30.09.05</date>
                <subclass>Э</subclass>
                </segment>
                <passenger>
                <surname>ИВАНОВ</surname>
                <name>ВАСИЛИЙ ПЕТРОВИЧ</name>
                <birthdate>01.06.78</birthdate>
                <sex>male</sex>
                <category>ААА</category>
                <doccode>ПС</doccode>
                <doc>1234561234</doc>
                <nationality>РФ</nationality>
                <phone type='mobile' comment='ЗВОНИТЬ ПОСЛЕ 19:00'>79101234567</phone>
                <phone type='work'>74957654321</phone>
                </passenger>
                <customer>
                <phone type='agency' comment='ДОП. ОФИС #15'>74991234567</phone>
                <email>webhelp@sirena-travel.ru</email>
                </customer>
                <answer_params>
                <show_tts>true</show_tts>
                </answer_params>
                </booking>
                </query>
                </sirena>";

            var rp = @"<sirena>
  <query>
    <booking>
      <answer_params>
        <lang>en</lang>
      </answer_params>
      <request_params>
        <tick_ser>ЭБМ</tick_ser>
      </request_params>
      <segment>
        <company>UN</company>
        <num>888</num>
        <departure>MIA</departure>
        <arrival>VKO</arrival>
        <date>17.07.13</date>
        <subclass>X</subclass>
      </segment>
      <segment>
        <company>UT</company>
        <num>591</num>
        <departure>VKO</departure>
        <arrival>UFA</arrival>
        <date>18.07.13</date>
        <subclass>X</subclass>
      </segment>
      <passenger>
        <family>yusupov</family>
        <name>azamat</name>
        <doccode>NP</doccode>
        <doc>712294311</doc>
        <pspexpire>25.10.20</pspexpire>
        <category>ААТ</category>
        <sex>male</sex>
        <age>10.02.80</age>
        <nationality>RU</nationality>
        <contact type=""email"">yusupova956@mail.ru</contact>
        <contact type=""mobile"">+7 9173404435</contact>
      </passenger>
      <contacts>
        <contact type=""email"">yusupova956@mail.ru</contact>
        <contact type=""mobile"">+7 9173404435</contact>
      </contacts>
    </booking>
  </query>
</sirena>";

            var r1 = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<sirena>
  <answer pult=""МОАР52"" msgid=""38"" time=""14:41:12 25.06.2013"">
    <booking regnum=""L82B5M"" agency=""11MOS"">
      <pnr>
        <passengers>
          <passenger id=""12"" lead_pass=""true"">
            <name>LEKSANDR</name>
            <surname>TRAVIN</surname>
            <sex>male</sex>
            <birthdate>28.02.1954</birthdate>
            <age>59</age>
            <doccode>NP</doccode>
            <doc>648233929</doc>
            <category rbm=""0"">AAT</category>
            <contacts>
              <email>ELENTRA66@RAMBLER.RU</email>
              <email>ELENTRA66@RAMBLER.RU</email>
              <contact type=""mobile"">79162166091</contact>
              <contact type=""mobile"">79162166091</contact>
            </contacts>
          </passenger>
          <passenger id=""14"">
            <name>ELENA</name>
            <surname>TRAVINA</surname>
            <sex>female</sex>
            <birthdate>22.08.1956</birthdate>
            <age>56</age>
            <doccode>NP</doccode>
            <doc>648233930</doc>
            <category rbm=""0"">AAT</category>
          </passenger>
        </passengers>
        <segments>
          <segment id=""14"">
            <company>S7</company>
            <flight>921</flight>
            <class>O</class>
            <subclass>O</subclass>
            <seatcount>2</seatcount>
            <departure>
              <city>MOW</city>
              <airport>DME</airport>
              <date>14.07.13</date>
              <time>11:40</time>
            </departure>
            <arrival>
              <city>VAR</city>
              <date>14.07.13</date>
              <time>13:35</time>
            </arrival>
            <status>confirmed</status>
            <airplane>310</airplane>
          </segment>
          <segment id=""15"">
            <company>S7</company>
            <flight>920</flight>
            <class>O</class>
            <subclass>O</subclass>
            <seatcount>2</seatcount>
            <departure>
              <city>VAR</city>
              <date>28.07.13</date>
              <time>20:35</time>
            </departure>
            <arrival>
              <city>MOW</city>
              <airport>DME</airport>
              <date>29.07.13</date>
              <time>00:25</time>
            </arrival>
            <status>confirmed</status>
            <airplane>320</airplane>
          </segment>
        </segments>
        <prices tick_ser=""ЭБМ"" fop=""CA"">
          <price segment-id=""14"" passenger-id=""12"" accode=""421"">
            <fare fare_expdate=""2013-06-28 14:41"">
              <code base_code=""OPORT14"">OPORT14</code>
              <value currency=""RUB"">6752.50</value>
            </fare>
            <taxes>
              <tax owner=""aircompany"">
                <code>ZZ</code>
                <value>125.00</value>
              </tax>
            </taxes>
          </price>
          <price segment-id=""14"" passenger-id=""14"" accode=""421"">
            <fare fare_expdate=""2013-06-28 14:41"">
              <code base_code=""OPORT14"">OPORT14</code>
              <value currency=""RUB"">6752.50</value>
            </fare>
            <taxes>
              <tax owner=""aircompany"">
                <code>ZZ</code>
                <value>125.00</value>
              </tax>
            </taxes>
          </price>
          <price segment-id=""15"" passenger-id=""12"" accode=""421"">
            <fare fare_expdate=""2013-06-28 14:41"">
              <code base_code=""OPORT14"">OPORT14</code>
              <value currency=""RUB"">6752.50</value>
            </fare>
            <taxes>
              <tax owner=""aircompany"">
                <code>BG</code>
                <value>344.00</value>
              </tax>
              <tax owner=""aircompany"">
                <code>ZF</code>
                <value>188.00</value>
              </tax>
              <tax owner=""aircompany"">
                <code>ZZ</code>
                <value>125.00</value>
              </tax>
            </taxes>
          </price>
          <price segment-id=""15"" passenger-id=""14"" accode=""421"">
            <fare fare_expdate=""2013-06-28 14:41"">
              <code base_code=""OPORT14"">OPORT14</code>
              <value currency=""RUB"">6752.50</value>
            </fare>
            <taxes>
              <tax owner=""aircompany"">
                <code>ZZ</code>
                <value>125.00</value>
              </tax>
              <tax owner=""aircompany"">
                <code>ZF</code>
                <value>188.00</value>
              </tax>
              <tax owner=""aircompany"">
                <code>BG</code>
                <value>344.00</value>
              </tax>
            </taxes>
          </price>
          <variant_total currency=""RUB"">28574.00</variant_total>
        </prices>
        <timelimit>28.06.13 14:41</timelimit>
        <regnum>Л82Б5М</regnum>
        <utc_timelimit>10:41 28.06.2013</utc_timelimit>
      </pnr>
      <contacts>
        <email>TKP@ZCTS.RU</email>
        <email>ELENTRA66@RAMBLER.RU</email>
        <contact type=""agency"">74959332033</contact>
        <contact type=""mobile"">79162166091</contact>
        <customer>
          <firstname></firstname>
          <lastname></lastname>
        </customer>
      </contacts>
      <latin_registration>true</latin_registration>
    </booking>
  </answer>
</sirena>";

            var rp2 = @"<sirena>
  <query>
    <booking>
      <answer_params>
        <lang>en</lang>
      </answer_params>
      <request_params>
        <tick_ser>ЭБМ</tick_ser>
      </request_params>
      <segment>
        <company>S7</company>
        <num>921</num>
        <departure>DME</departure>
        <arrival>VAR</arrival>
        <date>14.07.13</date>
        <subclass>O</subclass>
      </segment>
      <segment>
        <company>S7</company>
        <num>920</num>
        <departure>VAR</departure>
        <arrival>DME</arrival>
        <date>28.07.13</date>
        <subclass>O</subclass>
      </segment>
      <passenger>
        <family>TRAVIN</family>
        <name>LEKSANDR</name>
        <doccode>NP</doccode>
        <doc>648233929</doc>
        <pspexpire>19.06.18</pspexpire>
        <category>ААТ</category>
        <sex>male</sex>
        <age>28.02.54</age>
        <nationality>RU</nationality>
        <contact type=""email"">Elentra66@rambler.ru</contact>
        <contact type=""mobile"">+7 9162166091</contact>
        <contact type=""email"">Elentra66@rambler.ru</contact>
        <contact type=""mobile"">+7 9162166091</contact>
      </passenger>
      <passenger>
        <family>TRAVINA</family>
        <name>ELENA</name>
        <doccode>NP</doccode>
        <doc>648233930</doc>
        <pspexpire>19.06.18</pspexpire>
        <category>ААТ</category>
        <sex>female</sex>
        <age>22.08.56</age>
        <nationality>RU</nationality>
      </passenger>
      <contacts>
        <contact type=""email"">Elentra66@rambler.ru</contact>
        <contact type=""mobile"">+7 9162166091</contact>
      </contacts>
    </booking>
  </query>
</sirena>";


            var deserializedRequest = SerializationHelper.Deserialize<BookingRequest>(request);
            Console.WriteLine(SerializationHelper.Serialize(deserializedRequest));
        }

        [Test]
        public void BookingRequest_DeserializeComplexResponse1_ShouldNotFail()
        {
            var response = 
                @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <sirena>
                  <answer pult=""МОАР52"" msgid=""38"" time=""14:41:12 25.06.2013"">
                    <booking regnum=""L82B5M"" agency=""11MOS"">
                      <pnr>
                        <passengers>
                          <passenger id=""12"" lead_pass=""true"">
                            <name>LEKSANDR</name>
                            <surname>TRAVIN</surname>
                            <sex>male</sex>
                            <birthdate>28.02.1954</birthdate>
                            <age>59</age>
                            <doccode>NP</doccode>
                            <doc>648233929</doc>
                            <category rbm=""0"">AAT</category>
                            <contacts>
                              <email>ELENTRA66@RAMBLER.RU</email>
                              <email>ELENTRA66@RAMBLER.RU</email>
                              <contact type=""mobile"">79162166091</contact>
                              <contact type=""mobile"">79162166091</contact>
                            </contacts>
                          </passenger>
                          <passenger id=""14"">
                            <name>ELENA</name>
                            <surname>TRAVINA</surname>
                            <sex>female</sex>
                            <birthdate>22.08.1956</birthdate>
                            <age>56</age>
                            <doccode>NP</doccode>
                            <doc>648233930</doc>
                            <category rbm=""0"">AAT</category>
                          </passenger>
                        </passengers>
                        <segments>
                          <segment id=""14"">
                            <company>S7</company>
                            <flight>921</flight>
                            <class>O</class>
                            <subclass>O</subclass>
                            <seatcount>2</seatcount>
                            <departure>
                              <city>MOW</city>
                              <airport>DME</airport>
                              <date>14.07.13</date>
                              <time>11:40</time>
                            </departure>
                            <arrival>
                              <city>VAR</city>
                              <date>14.07.13</date>
                              <time>13:35</time>
                            </arrival>
                            <status>confirmed</status>
                            <airplane>310</airplane>
                          </segment>
                          <segment id=""15"">
                            <company>S7</company>
                            <flight>920</flight>
                            <class>O</class>
                            <subclass>O</subclass>
                            <seatcount>2</seatcount>
                            <departure>
                              <city>VAR</city>
                              <date>28.07.13</date>
                              <time>20:35</time>
                            </departure>
                            <arrival>
                              <city>MOW</city>
                              <airport>DME</airport>
                              <date>29.07.13</date>
                              <time>00:25</time>
                            </arrival>
                            <status>confirmed</status>
                            <airplane>320</airplane>
                          </segment>
                        </segments>
                        <prices tick_ser=""ЭБМ"" fop=""CA"">
                          <price segment-id=""14"" passenger-id=""12"" accode=""421"">
                            <fare fare_expdate=""2013-06-28 14:41"">
                              <code base_code=""OPORT14"">OPORT14</code>
                              <value currency=""RUB"">6752.50</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <price segment-id=""14"" passenger-id=""14"" accode=""421"">
                            <fare fare_expdate=""2013-06-28 14:41"">
                              <code base_code=""OPORT14"">OPORT14</code>
                              <value currency=""RUB"">6752.50</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <price segment-id=""15"" passenger-id=""12"" accode=""421"">
                            <fare fare_expdate=""2013-06-28 14:41"">
                              <code base_code=""OPORT14"">OPORT14</code>
                              <value currency=""RUB"">6752.50</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>BG</code>
                                <value>344.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>ZF</code>
                                <value>188.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <price segment-id=""15"" passenger-id=""14"" accode=""421"">
                            <fare fare_expdate=""2013-06-28 14:41"">
                              <code base_code=""OPORT14"">OPORT14</code>
                              <value currency=""RUB"">6752.50</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>ZF</code>
                                <value>188.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>BG</code>
                                <value>344.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <variant_total currency=""RUB"">28574.00</variant_total>
                        </prices>
                        <timelimit>28.06.13 14:41</timelimit>
                        <regnum>Л82Б5М</regnum>
                        <utc_timelimit>10:41 28.06.2013</utc_timelimit>
                      </pnr>
                      <contacts>
                        <email>TKP@ZCTS.RU</email>
                        <email>ELENTRA66@RAMBLER.RU</email>
                        <contact type=""agency"">74959332033</contact>
                        <contact type=""mobile"">79162166091</contact>
                        <customer>
                          <firstname></firstname>
                          <lastname></lastname>
                        </customer>
                      </contacts>
                      <latin_registration>true</latin_registration>
                    </booking>
                  </answer>
                </sirena>";

            var deserializedResponse = SerializationHelper.Deserialize<BookingResponse>(response);
            Assert.True(deserializedResponse.Answer.Body.LatinRegistration.Value == true);
            Assert.True(deserializedResponse.Answer.Body.Contacts.Emails[0] == "TKP@ZCTS.RU");
            Assert.True(deserializedResponse.Answer.Body.Contacts.Emails[1] == "ELENTRA66@RAMBLER.RU");
            Assert.True(deserializedResponse.Answer.Body.Contacts.ContactItems[0].ContactType == BookingContactType.Agency);
            Assert.True(deserializedResponse.Answer.Body.Contacts.ContactItems[1].ContactType == BookingContactType.Mobile);
            Assert.True(deserializedResponse.Answer.Body.Contacts.ContactItems[0].Value == "74959332033");
            Assert.True(deserializedResponse.Answer.Body.Contacts.ContactItems[1].Value == "79162166091");
        }

        [Test]
        public void BookingRequest_DeserializeComplexResponse2_ShouldNotFail()
        {
            var response =
                @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <sirena>
                  <answer pult=""МОАР89"" msgid=""17"" time=""07:47:10 20.06.2013"">
                    <booking regnum=""L74TG2"" agency=""11MOS"">
                      <pnr>
                        <passengers>
                          <passenger id=""12"" lead_pass=""true"">
                            <name>AZAMAT</name>
                            <surname>YUSUPOV</surname>
                            <sex>male</sex>
                            <birthdate>10.02.1980</birthdate>
                            <age>33</age>
                            <doccode>NP</doccode>
                            <doc>712294311</doc>
                            <category rbm=""0"">AAT</category>
                            <contacts>
                              <email>YUSUPOVA956@MAIL.RU</email>
                              <contact type=""mobile"">79173404435</contact>
                            </contacts>
                          </passenger>
                        </passengers>
                        <segments>
                          <segment id=""12"">
                            <company>UN</company>
                            <flight>888</flight>
                            <class>X</class>
                            <subclass>X</subclass>
                            <seatcount>1</seatcount>
                            <departure>
                              <city>MIA</city>
                              <airport>MIA</airport>
                              <date>17.07.13</date>
                              <time>18:35</time>
                              <terminal>F</terminal>
                            </departure>
                            <arrival>
                              <city>MOW</city>
                              <airport>VKO</airport>
                              <date>18.07.13</date>
                              <time>13:30</time>
                              <terminal>A</terminal>
                            </arrival>
                            <status>confirmed</status>
                            <airplane>744</airplane>
                          </segment>
                          <segment id=""13"">
                            <company>UT</company>
                            <flight>591</flight>
                            <class>X</class>
                            <subclass>X</subclass>
                            <seatcount>1</seatcount>
                            <departure>
                              <city>MOW</city>
                              <airport>VKO</airport>
                              <date>18.07.13</date>
                              <time>16:30</time>
                              <terminal>A</terminal>
                            </departure>
                            <arrival>
                              <city>UFA</city>
                              <airport>UFA</airport>
                              <date>18.07.13</date>
                              <time>20:25</time>
                              <terminal>1</terminal>
                            </arrival>
                            <status>confirmed</status>
                            <airplane>738</airplane>
                          </segment>
                        </segments>
                        <prices tick_ser=""ЭБМ"" fop=""CA"">
                          <price segment-id=""12"" passenger-id=""12"" accode=""670"">
                            <fare fare_expdate=""2013-06-20 23:59"">
                              <code base_code=""XHOWD3"">XHOWD3</code>
                              <value currency=""RUB"">17540.00</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>AY</code>
                                <value>80.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>US</code>
                                <value>551.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>YQ</code>
                                <value>2322.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>YR</code>
                                <value>516.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>XF</code>
                                <value>144.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <price segment-id=""13"" passenger-id=""12"" accode=""298"">
                            <fare fare_expdate=""2013-06-20 23:59"">
                              <code base_code=""XOW"">XOW</code>
                              <value currency=""RUB"">6490.00</value>
                            </fare>
                            <taxes>
                              <tax owner=""aircompany"">
                                <code>YQ</code>
                                <value>675.00</value>
                              </tax>
                              <tax owner=""aircompany"">
                                <code>ZZ</code>
                                <value>125.00</value>
                              </tax>
                            </taxes>
                          </price>
                          <variant_total currency=""RUB"">28568.00</variant_total>
                        </prices>
                        <timelimit>20.06.13 23:59</timelimit>
                        <regnum>Л74ТГ2</regnum>
                        <utc_timelimit>19:59 20.06.2013</utc_timelimit>
                      </pnr>
                      <contacts>
                        <email>TKP@ZCTS.RU</email>
                        <email>YUSUPOVA956@MAIL.RU</email>
                        <contact type=""agency"">74959332033</contact>
                        <contact type=""mobile"">79173404435</contact>
                        <customer>
                          <firstname></firstname>
                          <lastname></lastname>
                        </customer>
                      </contacts>
                      <latin_registration>true</latin_registration>
                    </booking>
                  </answer>
                </sirena>";

            var deserializedResponse = SerializationHelper.Deserialize<BookingResponse>(response);
            Console.WriteLine(deserializedResponse);
        }

        [Test]
        public void BookingRequest_SerializeDeserializeBookingCurrencyValue_ShouldNotFail()
        {
            var priceValue = new BookingCurrencyValue();
            priceValue.Currency = "RUR";
            priceValue.Value = 13.00f;

            var serializedPriceValue = SerializationHelper.Serialize(priceValue);
            priceValue = SerializationHelper.Deserialize<BookingCurrencyValue>(serializedPriceValue);
            Assert.True(priceValue.Currency == "RUR");
            Assert.True(priceValue.Value == 13.00f);
        }

        [Test]
        public void BookingRequest_SerializeDeserializeBookingPriceCode_ShouldNotFail()
        {
            var priceCode = new BookingPriceCode();
            priceCode.BaseCode = "OPORT14";
            priceCode.Value = "OPORT14";

            var serializedPriceCode = SerializationHelper.Serialize(priceCode);
            priceCode = SerializationHelper.Deserialize<BookingPriceCode>(serializedPriceCode);
            Assert.True(priceCode.Value == "OPORT14");
            Assert.True(priceCode.BaseCode == "OPORT14");
        }

        [Test]
        public void BookingRequest_DeserializeBookingPriceFare_ShouldNotFail()
        {
            var priceFare =
                @"<BookingPriceFare fare_expdate=""2013-06-28 14:41"">
                    <code base_code=""OPORT14"">OPORT14</code>
                    <value currency=""RUB"">6752.50</value>
                  </BookingPriceFare>";

            var deserializedPriceFare = SerializationHelper.Deserialize<BookingPriceFare>(priceFare);
            Assert.True(deserializedPriceFare.FareExpirationDate == new DateTime(2013, 6, 28, 14, 41, 0));
            Assert.True(deserializedPriceFare.Code.BaseCode == "OPORT14");
            Assert.True(deserializedPriceFare.Code.Value == "OPORT14");
            Assert.True(deserializedPriceFare.CurrencyValue.Currency == "RUB");
            Assert.True(deserializedPriceFare.CurrencyValue.Value == 6752.50f);
        }

        [Test]
        public void BookingRequest_DeserializeBookingPriceTax_ShouldNotFail()
        {
            var tax =
                @"<BookingPriceTax owner=""agency"">
                    <code>ZZ</code>
                    <value>125.00</value>
                 </BookingPriceTax>";

            var deserializedTax = SerializationHelper.Deserialize<BookingPriceTax>(tax);
            Assert.True(deserializedTax.Owner.HasValue);
            Assert.True(deserializedTax.Owner.Value == BookingTaxOwner.Agency);
            Assert.True(deserializedTax.Code.BaseCode == null);
            Assert.True(deserializedTax.Code.Value == "ZZ");
            Assert.True(deserializedTax.CurrencyValue.Currency == null);
            Assert.True(deserializedTax.CurrencyValue.Value == 125.00f);
        }

        [Test]
        public void BookingRequest_DeserializeBookingResponseSegment_ShouldNotFail()
        {
            var segment =
                @"<BookingResponseSegment id=""14"">
                    <company>S7</company>
                    <flight>921</flight>
                    <class>O</class>
                    <subclass>O</subclass>
                    <seatcount>2</seatcount>
                    <departure>
                        <city>MOW</city>
                        <airport>DME</airport>
                        <date>14.07.13</date>
                        <time>11:40</time>
                    </departure>
                    <arrival>
                        <city>VAR</city>
                        <date>14.07.13</date>
                        <time>13:35</time>
                    </arrival>
                    <status>confirmed</status>
                    <airplane>310</airplane>
                 </BookingResponseSegment>";

            var deserializedSegment = SerializationHelper.Deserialize<BookingResponseSegment>(segment);
            Assert.True(deserializedSegment.Company == "S7");
            Assert.True(deserializedSegment.FlightNumber == "921");
            Assert.True(deserializedSegment.SubClass == "O");
            Assert.True(deserializedSegment.Class == "O");
            Assert.True(deserializedSegment.SeatCount == 2);
            Assert.True(deserializedSegment.Status == BookingSegmentStatus.Confirmed);
            Assert.True(deserializedSegment.Airplane == "310");

            Assert.True(deserializedSegment.Departure.City == "MOW");
            Assert.True(deserializedSegment.Departure.Airport == "DME");
            Assert.True(deserializedSegment.Departure.Date == new DateTime(2013, 7, 14));
            Assert.True(deserializedSegment.Departure.Time == new TimeSpan(11, 40, 0));

            Assert.True(deserializedSegment.Arrival.City == "VAR");
            Assert.True(deserializedSegment.Arrival.Airport == null);
            Assert.True(deserializedSegment.Arrival.Date == new DateTime(2013, 7, 14));
            Assert.True(deserializedSegment.Arrival.Time == new TimeSpan(13, 35, 0));
        }

        [Test]
        public void BookingRequest_DeserializeBookingResponsePassenger_ShouldNotFail()
        {
            var passenger =
                @"<BookingResponsePassenger id=""12"" lead_pass=""true"">
                    <name>AZAMAT</name>
                    <surname>YUSUPOV</surname>
                    <sex>male</sex>
                    <birthdate>10.02.1980</birthdate>
                    <age>33</age>
                    <doccode>NP</doccode>
                    <doc>712294311</doc>
                    <category rbm=""0"">AAT</category>
                    <contacts>
                        <email>YUSUPOVA956@MAIL.RU</email>
                        <contact type=""mobile"">79173404435</contact>
                    </contacts>
                 </BookingResponsePassenger>";

            var deserializedPassenger = SerializationHelper.Deserialize<BookingResponsePassenger>(passenger);
            Assert.True(deserializedPassenger.Name == "AZAMAT");
            Assert.True(deserializedPassenger.Surname == "YUSUPOV");
            Assert.True(deserializedPassenger.Sex == BookingPassengerSex.Male);
            Assert.True(deserializedPassenger.BirthDate == new DateTime(1980, 2, 10));
            Assert.True(deserializedPassenger.Age.Value == 33);
            Assert.True(deserializedPassenger.DocumentType == "NP");
            Assert.True(deserializedPassenger.DocumentNumber == "712294311");
            Assert.True(deserializedPassenger.Category == "AAT");
            Assert.True(deserializedPassenger.Contacts.Email == "YUSUPOVA956@MAIL.RU");
            Assert.True(deserializedPassenger.Contacts.ContactItems[0].ContactType == BookingContactType.Mobile);
            Assert.True(deserializedPassenger.Contacts.ContactItems[0].Value == "79173404435");
        }
    }
}
