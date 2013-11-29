using System;
using System.Text;
using System.Linq;

using NUnit.Framework;

using Sirena.Helpers;

namespace Sirena.Tests
{
    [TestFixture]
    public class CryptographyHelperTests
    {
        [TestCase(
            "-----BEGIN PUBLIC KEY-----" +
            "MIGdMA0GCSqGSIb3DQEBAQUAA4GLADCBhwKBgQDX/J1aaaJ5KV3MJzdpjY8RCLwm" +
            "Z902aETHhJlnTifjFVdOfMoFAQ7Yk3qsYeE0kzP1QoGcW+rF6WR3JJY78ip9Eg8I"+
            "QJOq7mAVez4GlsSaV8CIUS/bP6L6Opo3o53mtgQ834i+0Vo5A6KKfXLEEkb0E99m" +
            "h0nZHtTyIaW94DWlqQIBAw==" +
            "-----END PUBLIC KEY-----")]
        public void PKCS1PublicKeyToRSAParameters_ShouldNotThrowException(String pkcs1PublicKey)
        {
            try
            {
                var rsaParams = CryptographyHelper.PKCS1PublicKeyToRSAParameters(pkcs1PublicKey);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestCase(
            "-----BEGIN PUBLIC KEY-----" +
            "MIGdMA0GCSqGSIb3DQEBAQUAA4GLADCBhwKBgQDX/J1aaaJ5KV3MJzdpjY8RCLwm" +
            "Z902aETHhJlnTifjFVdOfMoFAQ7Yk3qsYeE0kzP1QoGcW+rF6WR3JJY78ip9Eg8I"+
            "QJOq7mAVez4GlsSaV8CIUS/bP6L6Opo3o53mtgQ834i+0Vo5A6KKfXLEEkb0E99m" +
            "h0nZHtTyIaW94DWlqQIBAw==" +
            "-----END PUBLIC KEY-----",
            "1/ydWmmieSldzCc3aY2PEQi8JmfdNmhEx4SZZ04n4xVXTnzKBQEO2JN6rGHhNJMz9UKBnFvqxelkdySWO/IqfRIPCECTqu5gFXs+BpbEmlfAiFEv2z+i+jqaN6Od5rYEPN+IvtFaOQOiin1yxBJG9BPfZodJ2R7U8iGlveA1pak=",
            "Aw==")]
        public void PKCS1PublicKeyToRSAParameters_RSAParametersShouldBeEqual(String pkcs1PublicKey, String modulus, String exponent)
        {
            var rsaParams = CryptographyHelper.PKCS1PublicKeyToRSAParameters(pkcs1PublicKey);

            var rawModulus = Convert.FromBase64String(modulus);
            var rawExp = Convert.FromBase64String(exponent);

            Assert.True(Enumerable.SequenceEqual(rsaParams.Modulus, rawModulus));
            Assert.True(Enumerable.SequenceEqual(rsaParams.Exponent, rawExp));
        }
    }
}
