using System;
using System.ComponentModel.DataAnnotations;

namespace CxC_Seminario.Models
{
    public class EncabezadoFactura
    {
        public string IdEncabezado { get; set; }
        [Required]
        [StringLength(30)]
        public string IdEstudiante { get; set; }

        public DateTime FechaPago { get; set; }
        
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
       public double Descuento { get; set; }
       [Required]
        [RegularExpression("([0-9]+)")]
        public double TotalPagar { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        public double TotalCobrar { get; set; }

    }
}