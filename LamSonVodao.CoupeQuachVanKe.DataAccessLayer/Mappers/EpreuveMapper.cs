namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EpreuveMapper : DataMapper<Epreuve>
    {
        public EpreuveMapper()
        {
            this.ToTable("Epreuves");

            //this.HasKey(epreuve => epreuve.Id);           
            this.Property(epreuve => epreuve.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(epreuve => epreuve.Id).IsRequired();

            this.HasKey(epreuve => epreuve.Id);

            this.Property(epreuve => epreuve.Nom);

            this.Property(epreuve => epreuve.Statut).IsRequired();            

            this.Property(epreuve => epreuve.CategoriePratiquantId).IsRequired();

            this.Property(epreuve => epreuve.GenreCategorie).IsRequired();

            this.Property(epreuve => epreuve.GradeAutorise).IsRequired();

            this.HasRequired(epreuve => epreuve.TypeEpreuve).WithMany(te => te.Epreuves).HasForeignKey(te => te.TypeEpreuveId).WillCascadeOnDelete(true);            
        }
    }
}
