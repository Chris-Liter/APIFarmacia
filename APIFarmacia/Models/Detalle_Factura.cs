using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFarmacia.Models
{
    public class Detalle_Factura
    {
        [Key]
        public int det_id { get; set; }
        public int det_cantidad { get; set; }
        public double det_precio_unitario { get; set; }
        public double det_subtotal { get; set; }
        public double det_iva { get; set; }
        public double det_total { get; set; }
        [ForeignKey("producto_id")]
        public int producto_id { get; set; }
        [ForeignKey("factura_id")]
        public int factura_id { get; set; }
    }
}
