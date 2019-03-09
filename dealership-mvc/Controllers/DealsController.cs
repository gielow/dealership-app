using System.Collections.Generic;
using dealership.interfaces;
using dealership.model;
using Microsoft.AspNetCore.Mvc;

namespace dealership_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private IVehiclesProvider _repository;
        public DealsController(IVehiclesProvider provider)
        {
            _repository = provider;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
