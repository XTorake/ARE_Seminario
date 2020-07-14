using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class MetodoPago
    {
        [DisplayName("N° de Metodo")]
        public int IdMetodoPago { get; set; }
        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
