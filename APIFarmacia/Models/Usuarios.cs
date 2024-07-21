using System.ComponentModel.DataAnnotations;

namespace APIFarmacia.Models
{
    public class Usuarios
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string fechanacimiento { get; set; }             
        public string passwords { get; set; }
        public string permisos { get; set; }
    }
    public enum Permisos
    {
        Empleado = 0,
        Administrador = 1
    }
}
