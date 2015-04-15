using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class ParticipationMapper : DataMapper<Participation>
    {
        public ParticipationMapper()
        {
            this.ToTable("Participations");

            this.HasKey(p => p.Id);

            this.HasRequired(p => p.Competiteur).WithMany(c => c.Participations).HasForeignKey(p => p.CompetiteurId).WillCascadeOnDelete(false);

            this.HasRequired(p => p.Epreuve).WithMany(e => e.Participations).HasForeignKey(p => p.EpreuveId).WillCascadeOnDelete(false);

            this.HasRequired(p => p.Resultat).WithRequiredDependent(r => r.Participation).WillCascadeOnDelete(true);
        }
    }
}
