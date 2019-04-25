using LamSonVoDao.CoupeQuachVanKe.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern
{
    public class CoupeRepository<T> : IRepository<T> where T : class, IDataEntity
    {
        protected ObjectSet<T> objectSet;
        protected ObjectContext context;
        private bool disposed = false;

        public CoupeRepository(ObjectContext objectContext)
        {
            context = objectContext;
            objectSet = context.CreateObjectSet<T>();
        }

        public IEnumerable<T> Read()
        {
            return objectSet;
        }

        public IEnumerable<T> Read(Func<T, bool> predicate)
        {
            return objectSet.Where(predicate);
        }

        public T Read(int id)
        {
            return objectSet.FirstOrDefault(t => t.Id == id);
        }

        public T Read(T entity)
        {
            return objectSet.FirstOrDefault(t => t.Id == entity.Id);
        }

        public void Create(T entity)
        {
            objectSet.AddObject(entity);
        }

        public void Update(T entity)
        {
            objectSet.ApplyCurrentValues(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            objectSet.Attach(entity);
            objectSet.DeleteObject(entity);
            context.SaveChanges();
        }

        public IQueryable<T> Table
        {
            get { throw new NotImplementedException(); }
        }

        public bool Save()
        {
            return Convert.ToBoolean(context.SaveChanges());
        }

        public void Attach(T entity)
        {
            objectSet.Attach(Read(entity));
        }

        public void Detach(T entity)
        {
            objectSet.Detach(Read(entity.Id));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
