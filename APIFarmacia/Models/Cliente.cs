
using System.ComponentModel.DataAnnotations;

namespace APIFarmacia.Models
{
    public class Cliente
    {
        [Key]
        public int cli_id { get; set; }
        public string? cli_nombres { get; set; }
        public string? cli_cedula { get; set; } 
        public string? cli_apellidos { get; set; }
        public string? cli_direccion { get; set; }
        public string? cli_telefono { get; set; }
        public string? cli_correo { get; set; }
        public string? type_person { get; set; }

    }
    public enum TypePerson
    {
        proveedor,
        comprador
    }
}
