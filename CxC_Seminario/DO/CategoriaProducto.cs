using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class CategoriaProducto
    {
        public int IdCategoriaProducto { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]*$")]
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
