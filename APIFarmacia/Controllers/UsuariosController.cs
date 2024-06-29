using APIFarmacia.Contexts;
using APIFarmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ConexionPostgreSQL conexionSQLServer;
        public UsuariosController(ConexionPostgreSQL sql)
        {
            this.conexionSQLServer = sql;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return conexionSQLServer.Usuarios.ToList();
        }

        // GET api/<UsuariosController>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await conexionSQLServer.Usuarios.FindAsync(id);
            if(usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult<Usuarios>> saveUsuario(Usuarios usuario) 
        {
            conexionSQLServer.Usuarios.Add(usuario);
            await conexionSQLServer.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new {id =  usuario.id}, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuarios value)
        {
            if (id != value.id)
            {
                return BadRequest();
            }

            conexionSQLServer.Entry(value).State = EntityState.Modified;
            
            try
            {
                await conexionSQLServer.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProductoExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return Ok(value);
        }
        //private bool ProductoExists(int id)
        //{
        //    return conexionSQLServer.Usuarios.Any(e => e.Id == id);
        //}

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var usuario = await conexionSQLServer.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            conexionSQLServer.Usuarios.Remove(usuario);
            await conexionSQLServer.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("login/{nombre}/{password}")]
        public async Task<ActionResult<Usuarios>> Login(string nombre, string password)
        {
            var usuario = await conexionSQLServer.Usuarios.FirstOrDefaultAsync(opt => opt.nombre == nombre && opt.passwords == password);
            if (usuario == null)
                return NotFound("Contraseña o Usuario incorrecto");
            return Ok(usuario);
        }

    }
}
