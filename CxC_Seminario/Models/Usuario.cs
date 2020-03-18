using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Usuario
    {
        public string IdPersona { get; set; } //cedula
        [Required]
        [StringLength(30)]
        public string NombreUsuario { get; set; }
        [Required]
        [StringLength(20)]
        public string Contrasena { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdTipoUsuario { get; set; }
      
        [RegularExpression("([0-9]+)")]
        public int IdIglesia { get; set; }
        
        [RegularExpression("([0-9]+)")]
        public int IdMetodoPago { get; set; }
      
        [RegularExpression("([0-9]+)")]
        public int IdCarrera { get; set; }

    }

}