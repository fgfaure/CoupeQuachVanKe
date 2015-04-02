using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IEncadrantService
    {
        IEnumerable<Encadrant> GetAll();
        IEnumerable<Encadrant> Get(Func<Encadrant, bool> predicate);
        Encadrant GetById(object id);
        bool Insert(Encadrant entity);
        bool Update(Encadrant entity);
        bool Delete(Encadrant entity);
    }
}
