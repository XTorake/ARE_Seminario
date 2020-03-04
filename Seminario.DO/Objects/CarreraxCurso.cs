namespace Seminario.DO.Objects
{
    public class CarreraxCurso
    {
        public int IdRelacion { get; set; }
        public int IdCarrera { get; set; }
        public int IdCurso { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
