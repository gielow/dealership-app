using dealership.model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class VehicleTests
    {
        [Test]
        public void VehicleEqualsTest()
        {
            var vehicles = new List<Vehicle>();

            var bmw1 = new Vehicle()
            {
                Manufacturer = "BMW",
                Model = "X6",
                Year = 2015
            };

            var bmw2 = new Vehicle()
            {
                Manufacturer = "BMW",
                Model = "X6",
                Year = 2015
            };

            Assert.IsFalse(bmw1.Equals(null));
            Assert.IsTrue(bmw1.Equals(bmw2));
        }

        [Test]
        public void VehicleDistinctTest()
        {
            var vehicles = new List<Vehicle>();

            var bmw = new Vehicle()
            {
                Manufacturer = "BMW",
                Model = "X6",
                Year = 2015
            };

            vehicles.Add(bmw);
            vehicles.Add(bmw);

            var distinct = vehicles.Distinct();
            Assert.AreEqual(1, distinct.Count());
        }
    }
}