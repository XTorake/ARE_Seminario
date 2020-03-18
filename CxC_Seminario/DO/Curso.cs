using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Curso
    {
        public int IdCurso { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        public string IdProfesor { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Precio { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int Creditos { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarreraxCurso> CarreraxCursoes { get; set; }
    }
}
