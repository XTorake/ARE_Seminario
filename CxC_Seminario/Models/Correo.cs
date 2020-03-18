using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Correo
    {
        public int IdCorreo { get; set; }
        [Required]
        [StringLength(40)]
        public string DireccionCorreo { get; set; }
        [Required]
        [StringLength(12)]
        public string IdPersona { get; set; }

    }
}