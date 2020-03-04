﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CxC_Seminario.DO
{
    public class DistritoEclesiastico
    {
        public int IdDistritoEclesiastico { get; set; }
        public string Nombre { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iglesia> Iglesias { get; set; }
    }
}
