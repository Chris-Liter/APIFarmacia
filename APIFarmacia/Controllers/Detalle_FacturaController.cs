using APIFarmacia.Contexts;
using APIFarmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_FacturaController : ControllerBase
    {
        // GET: api/<Detalle_FacturaController>

        private readonly ConexionPostgreSQL conexionPostgreSQL;
        public Detalle_FacturaController(ConexionPostgreSQL conexionPostgreSQL)
        {
            this.conexionPostgreSQL = conexionPostgreSQL;
        }


        [HttpGet]
        public IEnumerable<Detalle_Factura> Get()
        {
            return conexionPostgreSQL.Detalle_Facturas.ToList();
        }

        // GET api/<Detalle_FacturaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle_Factura>> GetFactura(int id)
        {
            var usuario = await conexionPostgreSQL.Detalle_Facturas.FindAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);

        }

        // POST api/<Detalle_FacturaController>
        [HttpPost]
        public async Task<ActionResult<Detalle_Factura>> PostDetalle(Detalle_Factura detalle_Factura)
        {
            conexionPostgreSQL.Detalle_Facturas.Add(detalle_Factura);
            await conexionPostgreSQL.SaveChangesAsync();
            return CreatedAtAction(nameof(detalle_Factura), new { id = detalle_Factura.factura_id  }, detalle_Factura);
        }


        // PUT api/<Detalle_FacturaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, [FromBody] Detalle_Factura value)
        {
            if (id != value.factura_id)
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
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            var usuario = await conexionPostgreSQL.Detalle_Facturas.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            conexionPostgreSQL.Detalle_Facturas.Remove(usuario);
            await conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }

    }
}
