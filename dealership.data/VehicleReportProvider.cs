using dealership.interfaces;
using dealership.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace dealership.data
{
    public class VehicleReportProvider : IVehicleReportProvider
    {
        private ISalesProvider _salesProvider;

        public VehicleReportProvider(ISalesProvider salesProvider)
        {
            _salesProvider = salesProvider;
        }

        public IEnumerable<VehicleReport> GetByNumberOfSales()
        {
            IEnumerable<Sale> sales = _salesProvider.GetAll();

            var salesPerVehicle = sales.GroupBy(s => s.Vehicle).Select(group => new
            {
                Count = group.Count(),
                Amount = group.Sum(s => s.Price),
                Vehicle = group.Key
            })
            .OrderByDescending(g => g.Count);

            var result = new List<VehicleReport>();

            foreach (var item in salesPerVehicle)
            {
                result.Add(new VehicleReport()
                {
                    Count = item.Count,
                    SalesAmount = item.Amount,
                    Vehicle = item.Vehicle,
                });
            }

            return result;
        }
    }
}
