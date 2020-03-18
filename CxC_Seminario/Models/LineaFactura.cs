using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Lineafactura
    {
        public int IdLinea { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdProducto { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Monto { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Pago { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(5)]
        public string IdEncabezado { get; set; }

    }
}