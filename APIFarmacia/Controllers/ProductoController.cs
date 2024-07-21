using APIFarmacia.Contexts;
using APIFarmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ConexionPostgreSQL conexionPostgreSQL;
        public ProductoController(ConexionPostgreSQL conexionPostgreSQL)
        {
            this.conexionPostgreSQL = conexionPostgreSQL;
        }


        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            return conexionPostgreSQL.Productos.ToList();
        }

        // GET api/<Detalle_FacturaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await conexionPostgreSQL.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }


        // POST api/<Detalle_FacturaController>
        [HttpPost("crear")]
        public async Task<IActionResult> CreateProducto([FromBody] Productos producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto tiene campos faltantes");
            }

            try
            {
                conexionPostgreSQL.Productos.Add(producto);
                await conexionPostgreSQL.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductoById), new { id = producto.id }, producto);
            }
            catch (DbUpdateException ex)
            {
                // Manejar errores específicos de la base de datos
                return StatusCode(500, $"Error guardando los datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                return StatusCode(500, $"Ocurrió un error inesperado: {ex.Message}");
            }
        }




        // PUT api/<Detalle_FacturaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, [FromBody] Productos value)
        {
            if (id != value.id)
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
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var usuario = await conexionPostgreSQL.Productos.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            conexionPostgreSQL.Productos.Remove(usuario);
            await conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }
       
    }
}
