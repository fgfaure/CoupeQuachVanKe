using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IMedecinService
    {
        IEnumerable<Medecin> GetAll();
        IEnumerable<Medecin> Get(Func<Medecin, bool> predicate);
        Medecin GetById(object id);
        bool Insert(Medecin entity);
        bool Update(Medecin entity);
        bool Delete(Medecin entity);
    }
}
