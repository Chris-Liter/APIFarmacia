using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFarmacia.Models
{
    public class Citas
    {
        [Key]
        public int id { get; set; }
        public string fecha { get; set; }
        public string hora {  get; set; }
        public string turno {  get; set; }
        [ForeignKey("id_cliente")]
        public int id_cliente { get; set; }
    }
}
