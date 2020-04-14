using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.DO
{
    public class LineaFactura
    {
        public int IdLinea { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdProducto { get; set; }
       
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Pago { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(5)]
        public string IdEncabezado { get; set; }

        public virtual EncabezadoFactura EncabezadoFactura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
