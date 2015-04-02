using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface ICoupeService
    {
        IEnumerable<Coupe> GetAll();
        IEnumerable<Coupe> Get(Func<Coupe, bool> predicate);
        Coupe GetById(object id);
        bool Insert(Coupe entity);
        bool Update(Coupe entity);
        bool Delete(Coupe entity);
    }
}
