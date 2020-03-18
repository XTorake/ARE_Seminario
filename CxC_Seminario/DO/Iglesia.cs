using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Iglesia
    {
        public int IdIglesia { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdDistritoEclesiastico { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Descuento { get; set; }

        public virtual DistritoEclesiastico DistritoEclesiastico { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
