﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Seminario.DO.Objects
{
    public class Iglesia
    {
        public int IdIglesia { get; set; }
        public string Nombre { get; set; }
        public int IdDistritoEclesiastico { get; set; }
        public double Descuento { get; set; }

        public virtual DistritoEclesiastico DistritoEclesiastico { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
