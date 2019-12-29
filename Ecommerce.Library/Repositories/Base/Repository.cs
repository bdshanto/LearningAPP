using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Base
{
    public abstract class Repository<T> where T : class //type identifier
    {
        private DbContext _dbContext;

        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*DbSet<T> Table
        {
            get { return _dbContext.Set<T>(); }
        }*/
        private DbSet<T> Table => _dbContext.Set<T>();

        public virtual void Add(T entity)
        {
            Table.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
        public virtual T GetById(int id)
        {
            return Table.Find(id);
        }

    }
}