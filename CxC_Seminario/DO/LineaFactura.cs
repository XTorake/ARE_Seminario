using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class LineaFactura
    {
        public int idLinea { get; set; }
        public int idProducto { get; set; }
        public double monto { get; set; }
        public double pago { get; set; }
        public string descripcion { get; set; }
        public string idEncabezado { get; set; }

        public virtual EncabezadoFactura EncabezadoFactura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
