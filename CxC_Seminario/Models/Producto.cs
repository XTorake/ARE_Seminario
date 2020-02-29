using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CxC_Seminario.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public int IdCategoriaProducto { get; set; }

        public double Precio { get; set; }

    }
}