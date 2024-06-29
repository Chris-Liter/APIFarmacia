
using System.ComponentModel.DataAnnotations;

namespace APIFarmacia.Models
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string cedula {  get; set; }
        public string fechaNacimiento {  get; set; }
        public string correo {  get; set; }
        
    }
}
