using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario.DO.Objects
{
    public class Iglesia
    {
        public int idIglesia { get; set; }
        public string nombre { get; set; }
        public int idDistritoEclesiastico { get; set; }
        public double descuento { get; set; }

        //public virtual DistritoEclesiastico DistritoEclesiastico { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
