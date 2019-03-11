using NUnit.Framework;
using dealership.data.tests.Moqs;
using System.Linq;

namespace dealership.data.test
{
    public class VehicleReportProviderTests
    {
        private VehicleReportProvider _repository;

        [SetUp]
        public void Setup()
        {
            var salesRepositoryMoq = new SalesRepositoryMoq();
            _repository = new VehicleReportProvider(salesRepositoryMoq);
        }

        [Test]
        public void ReportBySalesTest()
        {
            var report = _repository.GetByNumberOfSales();
            var mostSoldCar = report?.FirstOrDefault();

            Assert.IsNotNull(mostSoldCar);
            Assert.IsNotNull(mostSoldCar.Vehicle);
            Assert.AreEqual("Beetle", mostSoldCar.Vehicle.Model);
            Assert.AreEqual(2, mostSoldCar.Count);
            Assert.AreEqual(180000, mostSoldCar.SalesAmount);
        }
    }
}