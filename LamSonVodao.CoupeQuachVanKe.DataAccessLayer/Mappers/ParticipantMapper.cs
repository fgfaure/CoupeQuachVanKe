using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class ParticipantMapper : DataMapper<Participant>
    {
        public ParticipantMapper()
        {
            this.ToTable("Participants");

            //this.HasKey(epreuve => epreuve.Id);           
            this.Property(epreuve => epreuve.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(epreuve => epreuve.Id).IsRequired();

            this.Property(c => c.Nom).IsRequired().HasMaxLength(255);

            this.HasRequired(c => c.Club).WithMany(club => club.Participants).HasForeignKey(c => c.ClubId).WillCascadeOnDelete(true);
        }
    }
}
