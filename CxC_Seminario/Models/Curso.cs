using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
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

    }
}