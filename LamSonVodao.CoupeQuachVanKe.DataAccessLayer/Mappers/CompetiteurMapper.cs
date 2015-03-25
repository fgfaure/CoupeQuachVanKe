using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class CompetiteurMapper : DataMapper<Competiteur>
    {
        public CompetiteurMapper() 
        {
            this.ToTable("Competiteurs");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Nom).IsRequired().HasMaxLength(255);

            this.Property(c => c.Prenom).IsRequired().HasMaxLength(255);

            this.Property(c => c.Grade).IsRequired();

            this.Property(c => c.Categorie).IsRequired();

            this.Property(c => c.DateNaissance).IsRequired().HasColumnType("smalldatetime");

            this.Property(c => c.Sexe).IsRequired();

            this.Property(c => c.LicenceFFKDA).IsRequired().HasMaxLength(255);

            this.Property(c => c.NbAnneePratique).IsRequired();            

            this.Property(c => c.Poids).IsOptional();

            this.Property(c => c.InscriptionValidePourCoupe).IsRequired();

            this.Property(c => c.InscritPourBaiVuKhi).IsRequired();

            this.Property(c => c.InscritPourCombat).IsRequired();

            this.Property(c => c.InscritPourQuyen).IsRequired();

            this.Property(c => c.InscritPourSongLuyen).IsRequired();

            this.Property(c => c.EquipeSongLuyen).IsRequired();

            this.HasRequired(c => c.Club).WithMany(club => club.Competiteurs).HasForeignKey(c => c.ClubId).WillCascadeOnDelete(true);

        }
    }
}
