using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Usuario
    {
        public string Cedula { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdIglesia { get; set; }
        public int? IdMetodoPago { get; set; }
        public int? IdCarrera { get; set; }
    }
}
