﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class Persona
    {
        [Required]
        [StringLength(12)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Primer Apellido")]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        [DisplayName("Id de Pais")]
        public int IdPais { get; set; }

      
        public virtual Pais Pais { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
