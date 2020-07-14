using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class DistritoEclesiastico
    {
        [DisplayName("N° Distrito")]
        public int IdDistritoEclesiastico { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iglesia> Iglesias { get; set; }
    }
}
