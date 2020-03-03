using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxC_Seminario.DO
{
    public class DistritoEclesiastico
    {
        public int idDistritoEclesiastico { get; set; }
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iglesia> Iglesias { get; set; }
    }
}
