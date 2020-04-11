using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Usuario
    {
        public string Cedula { get; set; }
        [Required]
        [StringLength(30)]
        public string Usuario1 { get; set; }
        [Required]
        [StringLength(20)]
        public string Contrasena { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public int IdTipoUsuario { get; set; }
        [RegularExpression("([0-9]+)")]
        public int? IdIglesia { get; set; }
        [RegularExpression("([0-9]+)")]
        public int? IdMetodoPago { get; set; }
        [RegularExpression("([0-9]+)")]
        public int? IdCarrera { get; set; }
        public bool? IsTemp { get; set; }
        public int? LoginCount { get; set; }

        public virtual Carrera Carrera { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public virtual Iglesia Iglesia { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
