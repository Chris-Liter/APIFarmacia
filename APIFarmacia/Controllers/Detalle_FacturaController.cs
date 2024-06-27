using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_FacturaController : ControllerBase
    {
        // GET: api/<Detalle_FacturaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Detalle_FacturaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Detalle_FacturaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Detalle_FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Detalle_FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
