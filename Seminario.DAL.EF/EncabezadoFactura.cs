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
    
    public partial class EncabezadoFactura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EncabezadoFactura()
        {
            this.LineaFacturas = new HashSet<LineaFactura>();
        }
    
        public string idEncabezado { get; set; }
        public string idEstudiante { get; set; }
        public System.DateTime fechaPago { get; set; }
        public string direccion { get; set; }
        public double totalPagar { get; set; }
        public double totalCobrar { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
