using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IResponsableCoupeService
    {
        IEnumerable<ResponsableCoupe> GetAll();
        IEnumerable<ResponsableCoupe> Get(Func<ResponsableCoupe, bool> predicate);
        ResponsableCoupe GetById(object id);
        bool Insert(ResponsableCoupe entity);
        bool Update(ResponsableCoupe entity);
        bool Delete(ResponsableCoupe entity);
    }
}
