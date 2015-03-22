using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface IClubService
    {
        IEnumerable<Club> GetAll();
        IEnumerable<Club> Get(Func<Club, bool> predicate);
        Club GetById(object id);
        bool Insert(Club entity);
        bool Update(Club entity);
        bool Delete(Club entity);
    }
}
