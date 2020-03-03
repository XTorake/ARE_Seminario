using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int idCategoriaProducto { get; set; }
        public double precio { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
