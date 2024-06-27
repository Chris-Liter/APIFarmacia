
using System.ComponentModel.DataAnnotations;

namespace APIFarmacia.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula {  get; set; }
        public string FechaNacimiento {  get; set; }
        public string Correo {  get; set; }
        
    }
}
