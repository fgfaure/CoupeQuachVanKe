
namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer
{
    using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System.Data.Entity;

    public class CoupeQuachVanKeContext : DbContext
    {
        public CoupeQuachVanKeContext()
            : base("name=CoupeQuachVanKeContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Aire> Aires { get; set; }
        public DbSet<UIColor> Colors { get; set; }
        public DbSet<Club> Clubs { get; set; }        
        public DbSet<Competiteur> Competiteurs { get; set; }
        public DbSet<Coupe> Coupes { get; set; }
        public DbSet<Disponibilite> Disponibilites { get; set; }
        public DbSet<Encadrant> Encadrants { get; set; }
        public DbSet<Encadrement> Encadrements { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<EpreuveCombat> EpreuvesCombat { get; set; }
        public DbSet<EpreuveTechnique> EpreuvesTechniques { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<ResponsableCoupe> Responsables { get; set; }
        public DbSet<ResponsableClub> ResponsableClub { get; set; }
        public DbSet<Resultat> Resultats { get; set; }
        public DbSet<NetClient> NetClients { get; set; }
        public DbSet<NetClientType> NetClientTypes { get; set; }


        public new IDbSet<Entity> Set<Entity>() where Entity : BaseEntity
        {
            return base.Set<Entity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                     
            modelBuilder.Configurations.Add(new AireMapper());
            modelBuilder.Configurations.Add(new UIColorMapper());
            modelBuilder.Configurations.Add(new ClubMapper());
            modelBuilder.Configurations.Add(new CompetiteurMapper());
            modelBuilder.Configurations.Add(new CoupeMapper());
            modelBuilder.Configurations.Add(new DisponibiliteMapper());
            modelBuilder.Configurations.Add(new EncadrantMapper());
            modelBuilder.Configurations.Add(new EncadrementMapper());
            modelBuilder.Configurations.Add(new EquipeMapper());
            modelBuilder.Configurations.Add(new EpreuveCombatMapper());
            modelBuilder.Configurations.Add(new EpreuveTechniqueMapper());
            modelBuilder.Configurations.Add(new MedecinMapper());
            modelBuilder.Configurations.Add(new ResponsableCoupeMapper());
            modelBuilder.Configurations.Add(new ResponsableClubMapper());
            modelBuilder.Configurations.Add(new ResultatMapper());
            modelBuilder.Configurations.Add(new NetClientMapper());
            modelBuilder.Configurations.Add(new NetClientTypeMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
