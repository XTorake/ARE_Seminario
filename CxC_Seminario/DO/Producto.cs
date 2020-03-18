using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdCategoriaProducto { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Precio { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
