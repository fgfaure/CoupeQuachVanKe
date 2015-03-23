using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
   public class ResponsableClubMapper : DataMapper<ResponsableClub>
    {
       public ResponsableClubMapper()
       {
           this.ToTable("ResponsablesClub");

           this.HasKey(r => r.Id);
           this.Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(r => r.Id).IsRequired();

           this.Property(r => r.Nom).IsRequired();
           this.Property(r => r.Nom).HasMaxLength(255);

           this.Property(r => r.Prenom).IsRequired();
           this.Property(r => r.Prenom).HasMaxLength(255);

           this.Property(r => r.Adresse).IsOptional();
           this.Property(r => r.Adresse).HasMaxLength(255);

           this.Property(r => r.Telephone).IsOptional();
           this.Property(r => r.Telephone).IsFixedLength().HasMaxLength(14);

           this.Property(r => r.EmailContact).IsOptional();
           this.Property(r => r.EmailContact).HasMaxLength(255);

           this.HasRequired(r => r.Club).WithMany().HasForeignKey(responsable => responsable.ClubId).WillCascadeOnDelete(false);
       }
    }
}
