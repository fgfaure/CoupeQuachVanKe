using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Mappers
{
    public class EpreuveTechniqueMapper : DataMapper<EpreuveTechnique>
    {
        public EpreuveTechniqueMapper()
        {
            this.ToTable("EpreuvesTechniques");
        }
    }
}
