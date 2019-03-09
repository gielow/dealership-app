using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;

namespace dealership.data.test
{
    public class VehicleRespositoryTests
    {
        private const string _cvsFileName = "dealertrack-example.csv";
        private VehicleRepository _repository;

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _cvsFileName);
            _repository = new VehicleRepository();
            _repository.SetFilePath(path);
        }

        [Test]
        public void LoadDoesNotThrowAndNotBullTest()
        {
            Assert.DoesNotThrow(() => _repository.GetAll());
            Assert.IsNotNull(_repository.GetAll());
        }

        [Test]
        public void DataValidationTest()
        {
            var vehicle = _repository.GetById(5469);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual("Milli Fulton", vehicle.CustomerName);
            Assert.AreEqual("Sun of Saskatoon", vehicle.DealershipName);
            Assert.AreEqual(2017, vehicle.Year);
            Assert.AreEqual("Ferrari 488 Spider", vehicle.Model);
            Assert.AreEqual(429987, vehicle.Price);
            Assert.AreEqual(new DateTime(2018, 6, 19), vehicle.Date.HasValue ? vehicle.Date.Value : DateTime.MinValue);
        }
    }
}