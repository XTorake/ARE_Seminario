using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.DO
{
    public class Factura
    {
        public EncabezadoFactura Encabezado { get; set; }
        public List<Producto> Productos { get; set; }
        public List<LineaFactura> Lineas{ get; set; }

    }
}