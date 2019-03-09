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
            Assert.AreEqual(429987.00, decimal.Parse("429,987"));
        }

        [Test]
        public void ParseDateTest()
        {
            Assert.AreEqual(429987.00, decimal.Parse("429,987"));
        }
    }
}