using System;
using System.Text;
using System.Threading;

using NUnit.Framework;

using Sirena.Cryptography;

namespace Sirena.Tests
{
    [TestFixture]
    public sealed class DESCryptographyTests
    {
        [Test]
        public void DESCryptography_ShouldNotBeNull()
        {
            var desCrypt = DESCryptography.Instance;
            Assert.NotNull(desCrypt.Key);
        }

        [TestCase("Simple Message")]
        [TestCase("For test method names")]
        [TestCase("This is similar to the advice on the Google")]
        public void DESCryptography_EncryptedThenDecryptedDataShouldBeEqualOrigin(String data)
        {
            var desCrypt = DESCryptography.Instance;
            var rawData = Encoding.UTF8.GetBytes(data);
            var encryptedData = desCrypt.Encrypt(rawData);
            var decryptedData = desCrypt.Decrypt(encryptedData);
            var resolvedData = Encoding.UTF8.GetString(decryptedData);
            Assert.AreEqual(data, resolvedData);
        }
    }
}
