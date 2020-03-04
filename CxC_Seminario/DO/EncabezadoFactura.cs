﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class EncabezadoFactura
    {
        public string IdEncabezado { get; set; }
        public string IdEstudiante { get; set; }
        public DateTime FechaPago { get; set; }
        public string Direccion { get; set; }
        public double Descuento { get; set; }
        public double TotalPagar { get; set; }
        public double TotalCobrar { get; set; }

        public virtual Usuario Usuario { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
