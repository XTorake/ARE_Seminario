using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        [Required]
        [StringLength(12)]
        public string IdPersona { get; set; } //cedula
        [Required]
        [RegularExpression("([0-9]+)")]
        public long Numero { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdCodigoPais { get; set; }

    }

}