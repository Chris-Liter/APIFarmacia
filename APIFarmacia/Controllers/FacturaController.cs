using APIFarmacia.Contexts;
using APIFarmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        // GET: api/<FacturaController>
        private readonly ConexionPostgreSQL conexionPostgreSQL;
        public FacturaController(ConexionPostgreSQL conexionPostgreSQL)
        {
            this.conexionPostgreSQL = conexionPostgreSQL;
        }


        [HttpGet]
        public IEnumerable<Factura> GetFactura()
        {
            return conexionPostgreSQL.Factura.ToList();
        }

        // GET api/<Detalle_FacturaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var usuario = await conexionPostgreSQL.Factura.FindAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);

        }

        // POST api/<Detalle_FacturaController>
        [HttpPost]
        public async Task<ActionResult<Detalle_Factura>> PostFactura(Factura factura)
        {
            conexionPostgreSQL.Factura.Add(factura);
            await conexionPostgreSQL.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFactura), new { id = factura.fac_id }, factura);
        }


        // PUT api/<Detalle_FacturaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, [FromBody] Factura value)
        {
            if (id != value.fac_id)
            {
                return BadRequest();
            }
            conexionPostgreSQL.Entry(value).State = EntityState.Modified;

            try
            {
                await conexionPostgreSQL.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(value);

        }

        // DELETE api/<Detalle_FacturaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var usuario = await conexionPostgreSQL.Factura.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            conexionPostgreSQL.Factura.Remove(usuario);
            await conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }
    }
}
