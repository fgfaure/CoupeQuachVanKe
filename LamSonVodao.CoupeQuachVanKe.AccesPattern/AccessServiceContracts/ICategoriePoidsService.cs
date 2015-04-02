using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface ICategoriePoidsService
    {
        IEnumerable<CategoriePoids> GetAll();
        IEnumerable<CategoriePoids> Get(Func<CategoriePoids, bool> predicate);
        CategoriePoids GetById(object id);
        bool Insert(CategoriePoids entity);
        bool Update(CategoriePoids entity);
        bool Delete(CategoriePoids entity);
    }
}
