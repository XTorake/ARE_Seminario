using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.DO
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        [Required]
        [StringLength(12)]
        public string Cedula { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int Telefono1 { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdCodigoPais { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
