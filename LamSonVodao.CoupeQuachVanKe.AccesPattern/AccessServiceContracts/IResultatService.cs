using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IResultatService
    {
        IEnumerable<Resultat> GetAll();
        IEnumerable<Resultat> Get(Func<Resultat, bool> predicate);
        Resultat GetById(object id);
        bool Insert(Resultat entity);
        bool Update(Resultat entity);
        bool Delete(Resultat entity);
    }
}
