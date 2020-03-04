namespace Seminario.DO.Objects
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        public string Cedula { get; set; }
        public int Telefono1 { get; set; }
        public int IdCodigoPais { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
