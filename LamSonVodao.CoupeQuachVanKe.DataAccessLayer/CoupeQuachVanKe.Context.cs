﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FGF_QVKEntities : DbContext
    {
        public FGF_QVKEntities()
            : base("name=FGF_QVKEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aire> Aires { get; set; }
        public virtual DbSet<CategoriePoid> CategoriePoids { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Competiteur> Competiteurs { get; set; }
        public virtual DbSet<Coupe> Coupes { get; set; }
        public virtual DbSet<Disponibilite> Disponibilites { get; set; }
        public virtual DbSet<Encadrant> Encadrants { get; set; }
        public virtual DbSet<Epreuve> Epreuves { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<Responsable> Responsables { get; set; }
        public virtual DbSet<ResponsablesClub> ResponsablesClubs { get; set; }
        public virtual DbSet<Resultat> Resultats { get; set; }
    }
}