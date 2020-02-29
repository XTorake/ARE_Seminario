using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.Models
{
    public class Lineafactura
    {
        public int idLinea { get; set; }

        public int idProducto { get; set; }

        public double Monto { get; set; }

        public double Pago { get; set; }

        public string Descripcion { get; set; }

        public string idEncabezado { get; set; }

    }
}