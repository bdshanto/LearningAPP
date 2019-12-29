using Ecommerce.Repository.Product;

namespace Ecommerce.Repository
{
    public interface IUnityOfWork
    {
         ProductRepository ProductRepository { get; }


         bool SaveChange();
    }
}