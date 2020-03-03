using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class Correo
    {
        public int idCorreo { get; set; }
        public string correo1 { get; set; }
        public string cedula { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
