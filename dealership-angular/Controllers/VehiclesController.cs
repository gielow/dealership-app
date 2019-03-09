using System;
using System.Collections.Generic;
using dealership.interfaces;
using dealership.model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace dealership_angular.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private ISalesProvider _provider;
        public VehiclesController(ISalesProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("[action]")]
        public IEnumerable<Vehicle> GetAll()
        {
            IEnumerable<Sale> sales = _provider.GetAll();

            return sales.Select(s => s.Vehicle).Distinct();
        }

        [HttpGet("[action]")]
        public IEnumerable<VehicleReport> GetVehicleReport()
        {
            IEnumerable<Sale> sales = _provider.GetAll();

            var salesPerVehicle = sales.GroupBy(s => s.Vehicle).Select(group => new
            {
                Count = group.Count(),
                Vehicle = group.Key
            })
            .OrderByDescending(g => g.Count);

            var result = new List<VehicleReport>();

            foreach (var item in salesPerVehicle)
            {
                result.Add(new VehicleReport()
                {
                    Count = item.Count,
                    Vehicle = item.Vehicle
                });
            }

            return result;
        }
    }
}
