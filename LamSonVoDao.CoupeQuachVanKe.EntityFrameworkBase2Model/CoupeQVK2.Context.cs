﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoupeQVK2Container : DbContext
    {
        public CoupeQVK2Container()
            : base("name=CoupeQVK2Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aire> Aires { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Competiteur> Competiteurs { get; set; }
        public virtual DbSet<Coupe> Coupes { get; set; }
        public virtual DbSet<Disponibilite> Disponibilites { get; set; }
        public virtual DbSet<Encadrant> Encadrants { get; set; }
        public virtual DbSet<Epreuve> Epreuves { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<ResponsableClub> ResponsablesClubs { get; set; }
        public virtual DbSet<ResponsableCoupe> ResponsablesCoupes { get; set; }
        public virtual DbSet<Resultat> Resultats { get; set; }
        public virtual DbSet<CategoriePratiquant> CategoriePratiquants { get; set; }
        public virtual DbSet<EquipeSongLuyen> EquipesSongLuyen { get; set; }
        public virtual DbSet<NetClient> NetClient { get; set; }
        public virtual DbSet<NetClientType> NetClientTypes { get; set; }
        public virtual DbSet<TypeEpreuve> TypeEpreuves { get; set; }
        public virtual DbSet<Participation> Participations { get; set; }
        public virtual DbSet<Encadrement> EncadrementSet { get; set; }
    }
}
