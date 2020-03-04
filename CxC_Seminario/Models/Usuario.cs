namespace CxC_Seminario.Models
{
    public class Usuario
    {
        public string IdPersona { get; set; } //cedula

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public int IdTipoUsuario { get; set; }

        public int IdIglesia { get; set; }

        public int IdMetodoPago { get; set; }

        public int IdCarrera { get; set; }

    }

}