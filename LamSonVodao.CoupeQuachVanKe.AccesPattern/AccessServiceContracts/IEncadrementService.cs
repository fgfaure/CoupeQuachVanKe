using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IEncadrementService
    {
        IEnumerable<Encadrement> GetAll();
        IEnumerable<Encadrement> Get(Func<Encadrement, bool> predicate);
        Encadrement GetById(object id);
        bool Insert(Encadrement entity);
        bool Update(Encadrement entity);
        bool Delete(Encadrement entity);
    }
}
