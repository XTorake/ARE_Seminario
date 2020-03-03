using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class CarreraxCurso
    {
        public int idRelacion { get; set; }
        public int idCarrera { get; set; }
        public int idCurso { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
