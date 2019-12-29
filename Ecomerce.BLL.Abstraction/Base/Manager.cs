using System.Collections.Generic;
using System.Linq;
using Ecomerce.BLL.Abstraction.Contracts;
using Ecommerce.Repository.Abstraction.Contracts; 
namespace Ecomerce.BLL.Abstraction.Base
{
    public abstract class Manager<T> where T : class //type identifier
    {
        private IRepository<T> _repository;

        protected Manager(IRepository<T> repository) 
        {
            _repository = repository;
        }
        
        public virtual bool Add(T entity)
        {
            _repository.Add(entity);
            return true;
        }

        public virtual bool Update(T entity)
        {
            _repository.Update(entity);
            return true;
        }

        public virtual bool Remove(T entity)
        {
            _repository.Remove(entity);
            return true;
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

    }
}