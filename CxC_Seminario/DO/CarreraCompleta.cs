using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.DO
{
    public class CarreraCompleta
    {
       public Carrera Carrera { get; set; }
       public CarreraxCurso CarreraxCursos { get; set; }
        public List<Curso> Cursos { get; set; }

    }
}