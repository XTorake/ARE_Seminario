using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdCategoriaProducto { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Precio { get; set; }

    }
}