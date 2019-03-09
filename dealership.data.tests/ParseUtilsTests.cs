using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;

namespace dealership.data.test
{
    public class ParseUtilsTests
    {
        [Test]
        public void ParsePriceTest()
        {
            Assert.AreEqual(429987.00, ParseUtils.ParseDecimalFromWithQuotes("429,987"));
            Assert.AreEqual(0, ParseUtils.ParseDecimalFromWithQuotes(string.Empty));
            Assert.AreEqual(0, ParseUtils.ParseDecimalFromWithQuotes(null));
        }

        [Test]
        public void ParseDateTest()
        {
            Assert.AreEqual(null, ParseUtils.ParseDateTimeFromWithQuotes(null));
            Assert.AreEqual(null, ParseUtils.ParseDateTimeFromWithQuotes(string.Empty));
            Assert.AreEqual(new DateTime(2018, 6, 19), ParseUtils.ParseDateTimeFromWithQuotes("6/19/2018"));
        }

        [Test]
        public void RemoveStringOuterQuotesTest()
        {
            Assert.AreEqual(string.Empty, ParseUtils.RemoveOuterQuotesFromString(null));
            Assert.AreEqual(string.Empty, ParseUtils.RemoveOuterQuotesFromString(string.Empty));
            Assert.AreEqual("StringWithoutQuotes", ParseUtils.RemoveOuterQuotesFromString("\"StringWithoutQuotes\""));
        }
    }
}