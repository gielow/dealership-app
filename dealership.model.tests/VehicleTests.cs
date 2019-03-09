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
            vehicles.Add(new Vehicle()
            {
                Manufacturer = "BMW",
                Model = "X6",
                Year = 2015
            });

            vehicles.Add(new Vehicle()
            {
                Manufacturer = "BMW",
                Model = "X6",
                Year = 2015
            });

            var distinct = vehicles.Distinct();

            Assert.AreEqual(1, distinct.Count());
        }
    }
}