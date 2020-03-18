using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

    }
}