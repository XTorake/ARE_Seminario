using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.DO.Objects
{
    public class Usuario
    {
        public string cedula { get; set; }
        public string usuario1 { get; set; }
        public string contrasena { get; set; }
        public int idTipoUsuario { get; set; }
        public Nullable<int> idIglesia { get; set; }
        public Nullable<int> idMetodoPago { get; set; }
        public Nullable<int> idCarrera { get; set; }

        //public virtual Carrera Carrera { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
        //public virtual Iglesia Iglesia { get; set; }
        //public virtual MetodoPago MetodoPago { get; set; }
        //public virtual Persona Persona { get; set; }
        //public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
