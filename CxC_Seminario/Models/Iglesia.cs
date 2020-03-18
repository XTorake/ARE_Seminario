using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
   
        public class Iglesia
        {
            public int IdIglesia { get; set; }
            [Required]
            [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdDistritoEclesiastico { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double Descuento { get; set; }

        }
    }