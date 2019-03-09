using System.Collections.Generic;
using dealership.interfaces;
using dealership.model;
using Microsoft.AspNetCore.Mvc;

namespace dealership_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISalesProvider _repository;
        public SalesController(ISalesProvider provider)
        {
            _repository = provider;
        }
        // GET api/sales
        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            return _repository.GetAll();
        }

        // GET api/sales/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/sales
        [HttpPost]
        public void Post([FromBody] Vehicle value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vehicle value)
        {
        }

        // DELETE api/sales/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
