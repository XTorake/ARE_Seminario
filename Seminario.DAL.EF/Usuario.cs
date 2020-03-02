//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seminario.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.EncabezadoFacturas = new HashSet<EncabezadoFactura>();
        }
    
        public string cedula { get; set; }
        public string usuario1 { get; set; }
        public string contrasena { get; set; }
        public int idTipoUsuario { get; set; }
        public Nullable<int> idIglesia { get; set; }
        public Nullable<int> idMetodoPago { get; set; }
        public Nullable<int> idCarrera { get; set; }
    
        public virtual Carrera Carrera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public virtual Iglesia Iglesia { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
