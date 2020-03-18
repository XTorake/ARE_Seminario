using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class CategoriaProducto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a - zA - Z] *$")]
        public string Nombre { get; set; }

    }
}