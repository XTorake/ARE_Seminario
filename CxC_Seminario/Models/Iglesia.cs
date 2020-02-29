using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.Models
{
    public class Iglesia
    {
        public class iglesia
        {
            public int IdIglesia { get; set; }

            public string Nombre { get; set; }

            public int IdDistritoEclesiastico { get; set; }

            public double Descuento { get; set; }

        }
    }
}