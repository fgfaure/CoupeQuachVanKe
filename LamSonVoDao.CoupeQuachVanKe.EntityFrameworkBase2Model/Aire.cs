//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LamSonVoDao.CoupeQuachVanKe.EntityFrameworkBase2Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aire()
        {
            this.Epreuves = new HashSet<Epreuve>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public int CoupeId { get; set; }
    
        public virtual Coupe Coupe { get; set; }
        public virtual NetClient NetClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Epreuve> Epreuves { get; set; }
    }
}
