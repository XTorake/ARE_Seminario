using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
