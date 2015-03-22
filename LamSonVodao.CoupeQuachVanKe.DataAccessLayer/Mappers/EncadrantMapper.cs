using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class EncadrantMapper : DataMapper<Encadrant>
    {
        public EncadrantMapper()
        {
            this.ToTable("Encadrants");

            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Id).IsRequired();

            this.Property(e => e.Nom).IsRequired().HasMaxLength(255);

            this.Property(e => e.Prenom).IsRequired().HasMaxLength(255);

            this.Property(e => e.MailContact).IsOptional().HasMaxLength(255);

            this.Property(e => e.TailleTenue).IsRequired();

            this.Property(e => e.EstCompetiteur).IsOptional();

            this.Property(e => e.Sexe).IsRequired();

            this.HasRequired(e => e.Club).WithMany(club => club.Encadrants).HasForeignKey(e => e.ClubId).WillCascadeOnDelete(false);
        }
    }
}
