using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;

namespace dealership.data.test
{
    public class SalesRepositoryTests
    {
        private const string _cvsFileName = "dealertrack-example.csv";
        private SalesRepository _repository;

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _cvsFileName);
            _repository = new SalesRepository();
            _repository.SetFilePath(path);
        }

        [Test]
        public void InvalidPathTest()
        {
            _repository = new SalesRepository();
            Assert.Catch<ArgumentNullException>(() => _repository.SetFilePath(null));
            Assert.Catch<ArgumentNullException>(() => _repository.SetFilePath(string.Empty));
            Assert.Catch<FileNotFoundException>(() => _repository.SetFilePath(Guid.NewGuid().ToString()));

        }

        [Test]
        public void LoadDoesNotThrowAndNotNullTest()
        {
            Assert.DoesNotThrow(() => _repository.GetAll());
            Assert.IsNotNull(_repository.GetAll());
            Assert.IsNotNull(_repository.GetAll());
        }

        [Test]
        public void DataValidationTest()
        {
            var sale = _repository.GetById(5469);

            Assert.IsNotNull(sale);

            Assert.AreEqual("Milli Fulton", sale.CustomerName);
            Assert.AreEqual("Sun of Saskatoon", sale.DealershipName);
            Assert.IsNotNull(sale.Vehicle);
            Assert.AreEqual(2017, sale.Vehicle.Year);
            Assert.AreEqual("Ferrari", sale.Vehicle.Manufacturer);
            Assert.AreEqual("488 Spider", sale.Vehicle.Model);
            Assert.AreEqual(429987, sale.Price);
            Assert.AreEqual(new DateTime(2018, 6, 19), sale.Date.HasValue ? sale.Date.Value : DateTime.MinValue);
        }

        [Test]
        public void SpecialCharactersTest()
        {
            var sale = _repository.GetById(5545);

            Assert.IsNotNull(sale);

            Assert.AreEqual("Élie Boutroux", sale.CustomerName);
        }
    }
}