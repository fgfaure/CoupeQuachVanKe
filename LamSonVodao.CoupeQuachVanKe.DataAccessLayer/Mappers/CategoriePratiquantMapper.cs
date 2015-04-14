

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriePratiquantMapper : DataMapper<CategoriePratiquant>
    {
        public CategoriePratiquantMapper()
        {
            this.ToTable("CategoriesPratiquant");

            this.HasKey(cp => cp.Id);

            //this.Property(cp => cp.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(cp => cp.AgeMax);

            this.Property(cp => cp.AgeMin);

            //HasMany(cp => cp.Epreuves).WithMany(e => e.Categorie).Map(cp => cp.ToTable("CategoriesPratiquantsEpreuves")
            //    .MapLeftKey("CategoriePratiquantId")
            //    .MapRightKey("EpreuveId"));         

        }
    }
}
