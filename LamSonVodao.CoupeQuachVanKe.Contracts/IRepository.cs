using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.Contracts
{
    public interface IRepository<T> 
    {
        IEnumerable<T> Read();
        IEnumerable<T> Read(Func<T, bool> predicate);
        T Read(int id);
        T Read(T entity);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        //IQueryable<T> Table { get; }
        //bool Save();       
    }
}
