using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts
{
    public interface INetClientService
    {
        IEnumerable<NetClient> GetAll();
        IEnumerable<NetClient> Get(Func<NetClient, bool> predicate);
        NetClient GetById(object id);
        bool Insert(NetClient entity);
        bool Update(NetClient entity);
        bool Delete(NetClient entity);
    }
}
