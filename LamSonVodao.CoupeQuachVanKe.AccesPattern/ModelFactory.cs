using LamSonVoDao.CoupeQuachVanKe.Contracts;
using LamSonVoDao.CoupeQuachVanKe.EntityFrameworkBase2Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern
{
    public class ModelFactory<T> where T : class, IDataEntity
    {
        private ModelFactory()
        {

        }

        public static IRepository<T> CreateManager()
        {
            return new CoupeRepository<T>(new CoupeQVK2Container());
        }
    }
}
