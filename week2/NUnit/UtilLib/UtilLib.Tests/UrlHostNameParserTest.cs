//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UtilLib;
using NUnit.Framework;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new UrlHostNameParser();
        }

        [Test]
        public void ParseHostName_ValidHttpUrl_ReturnsHostName()
        {
            string url = "http://example.com/path";
            string expected = "example.com";

            string actual = _parser.ParseHostName(url);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ParseHostName_ValidHttpsUrl_ReturnsHostName()
        {
            string url = "https://sub.domain.org/resource";
            string expected = "sub.domain.org";

            string actual = _parser.ParseHostName(url);

            //Assert.That(actual, Is.EqualTo("WRONG_VALUE"));
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void ParseHostName_NonHttpProtocol_ThrowsFormatException()
        {
            string url = "ftp://example.com";

            var ex = Assert.Throws<FormatException>(() => _parser.ParseHostName(url));
            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }

        [Test]
        public void ParseHostName_EmptyString_ThrowsFormatException()
        {
            string url = "";

            var ex = Assert.Throws<FormatException>(() => _parser.ParseHostName(url));
            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }

        [Test]
        public void ParseHostName_InvalidFormat_ThrowsFormatException()
        {
            string url = "justSomeText";

            Assert.Throws<FormatException>(() => _parser.ParseHostName(url));
        }
    }
}
