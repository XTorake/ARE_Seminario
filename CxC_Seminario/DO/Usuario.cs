using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Usuario
    {
        public string Cedula { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Nombre de Usuario")]
        [RegularExpression("^[a-z]*$")]

        public string Usuario1 { get; set; }
        [Required]
        [StringLength(20)]
        //[MinLength(8)]
        
        public string Contrasena { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        [DisplayName("Tipo de usuario")]
        public int IdTipoUsuario { get; set; }
        [RegularExpression("([0-9]+)")]
        [DisplayName("Iglesia")]
        public int? IdIglesia { get; set; }
        [RegularExpression("([0-9]+)")]
        [DisplayName("Metodo de pago")]
        public int? IdMetodoPago { get; set; }
        [RegularExpression("([0-9]+)")]
       
        public bool? IsTemp { get; set; }
        public int? LoginCount { get; set; }

        public string Correo { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int Descuento { get; set; }

        [Required]
        [RegularExpression("([0-9]+)")]
        public float MontoAdeudado { get; set; }


        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public virtual Iglesia Iglesia { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
