using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class CategoriaProducto
    {
        public int IdCategoriaProducto { get; set; }
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
