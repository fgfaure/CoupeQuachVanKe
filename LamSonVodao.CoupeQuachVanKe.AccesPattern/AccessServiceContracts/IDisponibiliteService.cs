using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IDisponibiliteService
    {
        IEnumerable<Disponibilite> GetAll();
        IEnumerable<Disponibilite> Get(Func<Disponibilite, bool> predicate);
        Disponibilite GetById(object id);
        bool Insert(Disponibilite entity);
        bool Update(Disponibilite entity);
        bool Delete(Disponibilite entity);
    }
}
