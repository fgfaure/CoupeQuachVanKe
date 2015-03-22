using LamSonVodao.CoupeQuachVanKe.DataAccessLayer;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern
{
/// <summary>
/// 
/// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly CoupeQuachVanKeContext context;
       /// <summary>
       /// The disposed
       /// </summary>
       private bool disposed;
       /// <summary>
       /// The repositories
       /// </summary>
       private Dictionary<string,object> repositories;

       /// <summary>
       /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
       /// </summary>
       /// <param name="context">The context.</param>
       public UnitOfWork(CoupeQuachVanKeContext context)
       {
           this.context = context;
       }

       /// <summary>
       /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
       /// </summary>
       public UnitOfWork()
       {
           context = new CoupeQuachVanKeContext();
       }

       /// <summary>
       /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
       /// </summary>
       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }

       /// <summary>
       /// Saves this instance.
       /// </summary>
       public void Save()
       {
           context.SaveChanges();
       }

       /// <summary>
       /// Releases unmanaged and - optionally - managed resources.
       /// </summary>
       /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
       public virtual void Dispose(bool disposing)
       {
           if (!disposed)
           {
               if (disposing)
               {
                   context.Dispose();
               }
           }
           disposed = true;
       }

       /// <summary>
       /// Repositories this instance.
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <returns></returns>
       public Repository<T> Repository<T>() where T : BaseEntity
       {
           if (repositories == null)
           {
               repositories = new Dictionary<string,object>();
           }

           var type = typeof(T).Name;

           if (!repositories.ContainsKey(type))
           {
               var repositoryType = typeof(Repository<>);
               var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
               repositories.Add(type, repositoryInstance);
           }
           return (Repository<T>)repositories[type];
       }
    }    
}
