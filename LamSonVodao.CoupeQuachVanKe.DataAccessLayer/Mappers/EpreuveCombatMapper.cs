using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class EpreuveCombatMapper : DataMapper<EpreuveCombat>
    {
        public EpreuveCombatMapper()
        {
            this.ToTable("EpreuvesCombat");

            this.Property(ec => ec.PoidsMini).IsRequired();
            this.Property(ec => ec.PoidsMaxi).IsRequired();
        }
    }
}
