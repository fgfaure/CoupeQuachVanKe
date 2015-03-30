namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
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

            this.Property(epreuve => epreuve.Nom).IsRequired().HasMaxLength(255);

            this.Property(epreuve => epreuve.Description).IsOptional().HasMaxLength(255);

            this.Property(epreuve => epreuve.Statut).IsRequired();            

            this.Property(epreuve => epreuve.Categorie).IsRequired();

            this.Property(epreuve => epreuve.GenreCategorie).IsRequired();

            this.Property(epreuve => epreuve.GradeAutorise).IsRequired();            

            this.HasRequired(epreuve => epreuve.TypeEpreuve).WithMany(te => te.Epreuves).HasForeignKey(te => te.TypeEpreuveId);
        }
    }
}
