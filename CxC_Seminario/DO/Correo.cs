using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.DO
{
    public class Correo
    {
        public int IdCorreo { get; set; }
        [Required]
        [StringLength(40)]
        public string Correo1 { get; set; }
        [Required]
        [StringLength(12)]
        public string Cedula { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
