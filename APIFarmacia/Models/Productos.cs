using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFarmacia.Models
{
    public class Productos
    {
        [Key]
        public int id { get; set; }
        public string codigo_producto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public double iva { get; set; }

    }
}
