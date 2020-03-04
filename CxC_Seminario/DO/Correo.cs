namespace CxC_Seminario.DO
{
    public class Correo
    {
        public int IdCorreo { get; set; }
        public string Correo1 { get; set; }
        public string Cedula { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
