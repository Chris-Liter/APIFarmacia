using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFarmacia.Models
{
    public class Factura
    {
        [Key]
        public int fac_id { get; set; }
        public string? fac_tipo { get; set; }
        public double fac_numero { get; set; }
        public string? fac_fecha { get; set; }
        public double? fac_subtotal { get; set; }
        public double? fac_total_iva { get; set; }
        public double? fac_total { get; set; }
        [ForeignKey("id_cliente")]
        public int? id_cliente { get; set; }
        [ForeignKey("id_usuario")]
        public int? id_usuario {  get; set; }
    }
}
