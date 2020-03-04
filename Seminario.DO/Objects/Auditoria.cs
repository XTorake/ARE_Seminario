using System;

namespace Seminario.DO.Objects
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public string Usuario { get; set; }
        public string TablaAfectada { get; set; }
        public string Columna { get; set; }
        public string ValorViejo { get; set; }
        public string ValorNuevo { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
    }
}
