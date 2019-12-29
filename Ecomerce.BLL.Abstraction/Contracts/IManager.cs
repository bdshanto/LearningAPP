using System.Collections.Generic;

namespace Ecomerce.BLL.Abstraction.Contracts
{
    public interface IManager<T> where T : class
    {
        bool Add(T entity);


        bool Update(T entity);


        bool Remove(T entity);


        ICollection<T> GetAll();

        T GetById(int id);

    }
}