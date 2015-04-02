using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IResponsableClubService
    {
        IEnumerable<ResponsableClub> GetAll();
        IEnumerable<ResponsableClub> Get(Func<ResponsableClub, bool> predicate);
        ResponsableClub GetById(object id);
        bool Insert(ResponsableClub entity);
        bool Update(ResponsableClub entity);
        bool Delete(ResponsableClub entity);
    }
}
