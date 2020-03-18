using System.ComponentModel.DataAnnotations;


namespace CxC_Seminario.Models
{
    public class Carrera
    {
       
        public int IdCarrera { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^[a - zA - Z] *$")]

        public string Nombre { get; set; }

    }
}