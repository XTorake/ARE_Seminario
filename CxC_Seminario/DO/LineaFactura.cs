using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.DO
{
    public class LineaFactura
    {
        [DisplayName("N° Linea")]
        public int IdLinea { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        [DisplayName("N° Producto")]
        public int IdProducto { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(5)]
        [DisplayName("N° Factura")]
        public string IdEncabezado { get; set; }

        public virtual EncabezadoFactura EncabezadoFactura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
