using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class EncabezadoFactura
    {
        [DisplayName("N° de Factura")]
        public string IdEncabezado { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Usuario")]
        public string IdEstudiante { get; set; }
        [DisplayName("Fecha de pago")]
        public DateTime FechaPago { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        [DisplayName("Total a Pagar")]
        [Required]
        [RegularExpression("([0-9]+)")]
        public double TotalPagar { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        [DisplayName("Total a Cobrar")]
        public double TotalCobrar { get; set; }

        public virtual Usuario Usuario { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaFactura> LineaFacturas { get; set; }
    }
}
