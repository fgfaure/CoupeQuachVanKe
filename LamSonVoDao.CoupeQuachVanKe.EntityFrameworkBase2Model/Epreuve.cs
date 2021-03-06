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
    
    public partial class Epreuve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Epreuve()
        {
            this.Participations = new HashSet<Participation>();
            this.Encadrements = new HashSet<Encadrement>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Statut { get; set; }
        public int GenreCategorie { get; set; }
        public int GradeAutorise { get; set; }
        public bool IsMerged { get; set; }
    
        public virtual Aire Aire { get; set; }
        public virtual CategoriePratiquant CategoriePratiquant { get; set; }
        public virtual TypeEpreuve TypeEpreuve { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participation> Participations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encadrement> Encadrements { get; set; }
    }
}
