using System.Collections.Generic;
 
using System.Linq;
using Ecommerce.Repository.Abstraction.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Repository.Abstraction.Base
{
    public abstract class Repository<T>:IRepository<T> where T : class //type identifier
    {
        private DbContext _db;
          
        protected Repository(DbContext db)
        {
            _db = db;
        } 

         DbSet<T> Table
        {
            get { return _db.Set<T>(); }
        } 
       // private DbSet<T> Table => _db.Set<T>();

        public virtual void Add(T entity)
        {
            Table.Add(entity);
            _db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
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