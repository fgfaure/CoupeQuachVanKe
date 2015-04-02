using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IAireService
    {
        IEnumerable<Aire> GetAll();
        IEnumerable<Aire> Get(Func<Aire, bool> predicate);
        Aire GetById(object id);
        bool Insert(Aire entity);
        bool Update(Aire entity);
        bool Delete(Aire entity);
    }
}
