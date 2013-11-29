using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirena.Tests
{
    [TestFixture]
    public class QueryHeaderTests
    {
        [Test]
        public void QueryHeader_HeaderShouldBeEqualOriginal()
        {
            var originHeader = new QueryHeader(387, 372, ConnectionMode.Zipped);
            var cloneHeader = new QueryHeader(originHeader.HeaderData);

            Assert.AreEqual(originHeader.UserId, cloneHeader.UserId);
            Assert.AreEqual(originHeader.ConnectionMode, cloneHeader.ConnectionMode);
            Assert.AreEqual(originHeader.SymmetricKeyId, cloneHeader.SymmetricKeyId);
            Assert.AreEqual(originHeader.MessageLength, cloneHeader.MessageLength);
        }
    }
}
