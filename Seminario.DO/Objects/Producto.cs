using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoriaProducto { get; set; }
        public double Precio { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
