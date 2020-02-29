﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.Models
{
    public class EncabezadoFactura
    {
        public string IdEncabezado { get; set; }

        public string idEstudiante { get; set; }

        public DateTime FechaPago { get; set; }

        public string Direccion { get; set; }

        public double Descuento { get; set; }

        public double TotalPagar { get; set; }

        public double TotalCobrar { get; set; }

    }
}