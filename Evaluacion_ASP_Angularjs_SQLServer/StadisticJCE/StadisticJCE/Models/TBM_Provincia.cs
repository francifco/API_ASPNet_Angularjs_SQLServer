//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StadisticJCE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBM_Provincia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBM_Provincia()
        {
            this.TBM_Ciudadanos = new HashSet<TBM_Ciudadanos>();
        }
    
        public int idProvincia { get; set; }
        public string provincia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBM_Ciudadanos> TBM_Ciudadanos { get; set; }
    }
}
