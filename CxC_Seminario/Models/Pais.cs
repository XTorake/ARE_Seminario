using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Pais
    {
        public int IdPais { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int CodigoPais { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Descuento { get; set; }

    }
}