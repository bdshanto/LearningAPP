using System.Collections.Generic;
using Ecommerce.Repository.Abstraction.Base;

namespace Ecommerce.Repository.Abstraction.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}