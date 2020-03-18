using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(15)]
        public string Nombre { get; set; }

    }
}