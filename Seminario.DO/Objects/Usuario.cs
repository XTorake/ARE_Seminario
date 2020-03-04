using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Usuario
    {
        public string Cedula { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdIglesia { get; set; }
        public int? IdMetodoPago { get; set; }
        public int? IdCarrera { get; set; }

        public virtual Carrera Carrera { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public virtual Iglesia Iglesia { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
