using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.DO.Objects
{
    public class EncabezadoFactura
    {
        public string idEncabezado { get; set; }
        public string idEstudiante { get; set; }
        public System.DateTime fechaPago { get; set; }
        public string direccion { get; set; }
        public double descuento { get; set; }
        public double totalPagar { get; set; }
        public double totalCobrar { get; set; }

        //public virtual Usuario Usuario { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
