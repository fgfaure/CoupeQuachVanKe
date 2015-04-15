namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

    public class EquipeSongLuyenMapper : DataMapper<EquipeSongLuyen>
    {
        public EquipeSongLuyenMapper()
        {
            this.ToTable("EquipesSongLuyen");

            this.Property(c => c.Numero).IsRequired();

            //this.HasRequired(c => c.Club).WithMany(club => club.EquipesSongLuyen).HasForeignKey(c => c.ClubId).WillCascadeOnDelete(false);

            //this.HasMany(c => c.Competiteurs)..Map(e => e.EquipeSongLuyenId).WillCascadeOnDelete(false);
        }
    }
}
