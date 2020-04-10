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
        public int? IdCarrera { get; set; }
    }
}
