using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class Auditoria
    {
        public int idAuditoria { get; set; }
        public string usuario { get; set; }
        public string tablaAfectada { get; set; }
        public string columna { get; set; }
        public string valorViejo { get; set; }
        public string valorNuevo { get; set; }
        public System.DateTime fecha { get; set; }
        public string accion { get; set; }
    }
}
