namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriePoidsMapper : DataMapper<CategoriePoids>
    {
        public CategoriePoidsMapper()
        {
            this.ToTable("CategoriePoids");

            this.HasKey(catPoids => catPoids.EpreuveId);
            this.Property(catPoids => catPoids.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(catPoids => catPoids.Id).IsRequired();

            this.Property(catPoids => catPoids.Nom).IsRequired();
            this.Property(catPoids => catPoids.Nom).HasMaxLength(255);

            this.Property(catPoids => catPoids.Description).IsOptional();
            this.Property(catPoids => catPoids.Description).HasMaxLength(255);       

            this.Property(catPoids => catPoids.ValeurBasse).IsRequired();            

            this.Property(catPoids => catPoids.Description).IsRequired();

            this.HasRequired(catpoids => catpoids.Epreuve).WithRequiredDependent(epreuve => epreuve.CategoriePoids).WillCascadeOnDelete(true);
        }
    }
}
