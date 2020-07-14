using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Usuario
    {
        public string Cedula { get; set; }
        [Column("usuario")]
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdIglesia { get; set; }
        public int? IdMetodoPago { get; set; }

        public bool? IsTemp { get; set; }
        public int? loginCount { get; set; }
        public string correo { get; set; }
        public int Descuento { get; set; }
        public float MontoAdeudado { get; set; }

    }
}
