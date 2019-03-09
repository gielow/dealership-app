using System;
using System.Linq;
using System.Collections.Generic;
using dealership.interfaces;
using dealership.model;
using Microsoft.AspNetCore.Mvc;

namespace dealership_angular.Controllers
{
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        private ISalesProvider _provider;
        public SalesController(ISalesProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("[action]")]
        public IEnumerable<Sale> GetAll()
        {
            return _provider.GetAll().OrderByDescending(s => s.Date);
        }
    }
}
