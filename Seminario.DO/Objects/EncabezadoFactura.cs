using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class EncabezadoFactura
    {
        public string IdEncabezado { get; set; }
        public string IdEstudiante { get; set; }
        public DateTime FechaPago { get; set; }
        public string Direccion { get; set; }
        public double TotalPagar { get; set; }
        public double TotalCobrar { get; set; }

    }
}
