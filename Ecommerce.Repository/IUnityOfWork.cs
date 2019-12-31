using Ecommerce.Repository.Products;

namespace Ecommerce.Repository
{
    public interface IUnityOfWork
    {
         ProductRepository ProductRepository { get; } 

         bool SaveChange();
    }
}