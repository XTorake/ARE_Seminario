using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class DistritoEclesiastico
    {
        public int IdDistritoEclesiastico { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

    }

}