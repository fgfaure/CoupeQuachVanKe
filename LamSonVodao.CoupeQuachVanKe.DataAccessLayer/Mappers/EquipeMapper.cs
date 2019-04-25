namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

    public class EquipeMapper : DataMapper<Equipe>
    {
        public EquipeMapper()
        {
            this.ToTable("Equipes");

            this.Property(c => c.Numero).IsRequired();

            this.Property(c => c.TeamName).IsOptional();

            //this.HasRequired(c => c.Club).WithMany(club => club.EquipesSongLuyen).HasForeignKey(c => c.ClubId).WillCascadeOnDelete(false);

            //this.HasMany(c => c.Competiteurs)..Map(e => e.EquipeSongLuyenId).WillCascadeOnDelete(false);
        }
    }
}
