namespace Ecommerce.Library.Repositories
{
    public interface IUnityOfWork
    {
         ProductRepository ProductRepository { get; }


         bool SaveChange();
    }
}