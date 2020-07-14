using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class TipoUsuario
    {
        [DisplayName("N° Tipo de usuario")]
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(15)]
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
