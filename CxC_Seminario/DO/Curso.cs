using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string IdProfesor { get; set; }
        public double Precio { get; set; }
        public int Creditos { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarreraxCurso> CarreraxCursoes { get; set; }
    }
}
