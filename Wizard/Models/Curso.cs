//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wizard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            this.CarreraxCursoes = new HashSet<CarreraxCurso>();
        }
    
        public int idCurso { get; set; }
        public string nombre { get; set; }
        public string idProfesor { get; set; }
        public double precio { get; set; }
        public int creditos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarreraxCurso> CarreraxCursoes { get; set; }
    }
}
