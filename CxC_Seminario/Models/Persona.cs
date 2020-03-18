using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Persona
    {
        [Required]
        [StringLength(12)]
        public int Cedula { get; set; }
        [Required]
        [StringLength(20)]
        public int Nombre { get; set; }
        [Required]
        [StringLength(20)]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(20)]
        public string Apellido2 { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public string IdPais { get; set; }

    }

}