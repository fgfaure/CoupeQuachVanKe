using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IEpreuveService
    {
        IEnumerable<Epreuve> GetAll();
        IEnumerable<Epreuve> Get(Func<Epreuve, bool> predicate);
        Epreuve GetById(object id);
        bool Insert(Epreuve entity);
        bool Update(Epreuve entity);
        bool Delete(Epreuve entity);
    }
}
