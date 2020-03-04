using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public int CodigoPais { get; set; }
        public double Descuento { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Personas { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefono> Telefonoes { get; set; }
    }
}
