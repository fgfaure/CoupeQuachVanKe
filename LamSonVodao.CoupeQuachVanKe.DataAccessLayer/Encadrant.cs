//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Encadrant
    {
        public Encadrant()
        {
            this.Disponibilites = new HashSet<Disponibilite>();
            this.Epreuves = new HashSet<Epreuve>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string MailContact { get; set; }
        public int TailleTenue { get; set; }
        public Nullable<bool> EstCompetiteur { get; set; }
        public int Sexe { get; set; }
        public Nullable<int> Club_Id { get; set; }
        public int ClubId { get; set; }
        public Nullable<int> Coupe_Id { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Club Club1 { get; set; }
        public virtual Coupe Coupe { get; set; }
        public virtual ICollection<Disponibilite> Disponibilites { get; set; }
        public virtual ICollection<Epreuve> Epreuves { get; set; }
    }
}
