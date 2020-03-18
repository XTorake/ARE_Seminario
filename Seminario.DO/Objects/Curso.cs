using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string IdProfesor { get; set; }
        public double Precio { get; set; }
        public int Creditos { get; set; }
    }
}
