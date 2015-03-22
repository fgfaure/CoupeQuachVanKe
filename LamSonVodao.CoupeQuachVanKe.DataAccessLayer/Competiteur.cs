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
    
    public partial class Competiteur
    {
        public Competiteur()
        {
            this.Resultats = new HashSet<Resultat>();
            this.Epreuves = new HashSet<Epreuve>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Grade { get; set; }
        public int Categorie { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public int Sexe { get; set; }
        public string LicenceFFKDA { get; set; }
        public int AnneePratique { get; set; }
        public Nullable<int> Poids { get; set; }
        public Nullable<bool> InscriptionValidee { get; set; }
        public int ClubId { get; set; }
        public Nullable<int> Club_Id1 { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Club Club1 { get; set; }
        public virtual ICollection<Resultat> Resultats { get; set; }
        public virtual ICollection<Epreuve> Epreuves { get; set; }
    }
}
