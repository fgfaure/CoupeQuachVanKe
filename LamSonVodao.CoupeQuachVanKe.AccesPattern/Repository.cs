using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVoDao.CoupeQuachVanKe.AccesPattern
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly CoupeQuachVanKeContext context;
        /// <summary>
        /// The entities
        /// </summary>
        private IDbSet<T> entities;
        /// <summary>
        /// The error message
        /// </summary>
        private string errorMessage = string.Empty;

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(CoupeQuachVanKeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return this.Entities.ToList().Where(predicate);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public bool Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);
                return this.context.SaveChanges() != 0;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public bool Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.context.Entry<T>(entity).State = EntityState.Modified;
                return this.context.SaveChanges() != 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        /// <exception cref="System.Exception"></exception>
        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                return this.context.SaveChanges()!=0;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
    }
}
