using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface INetClientTypeService
    {
        IEnumerable<NetClientType> GetAll();
        IEnumerable<NetClientType> Get(Func<NetClientType, bool> predicate);
        NetClientType GetById(object id);
        bool Insert(NetClientType entity);
        bool Update(NetClientType entity);
        bool Delete(NetClientType entity);
    }
}
