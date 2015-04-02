using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface ICompetiteurService
    {
        IEnumerable<Competiteur> GetAll();
        IEnumerable<Competiteur> Get(Func<Competiteur, bool> predicate);
        Competiteur GetById(object id);
        bool Insert(Competiteur entity);
        bool Update(Competiteur entity);
        bool Delete(Competiteur entity);
    }
}
