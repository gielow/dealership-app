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
        private IVehicleReportProvider _provider;
        public VehiclesController(IVehicleReportProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("[action]")]
        public IEnumerable<VehicleReport> GetVehicleReport()
        {
            return _provider.GetByNumberOfSales();
        }
    }
}
