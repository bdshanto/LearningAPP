using Ecommerce.Library.DatabaseContext;

namespace Ecommerce.Library.Repositories
{
    public class UnityOfWork:IUnityOfWork
    {
        private EcommerceDatabaseContext _db;
        public UnityOfWork(EcommerceDatabaseContext db)
        {
            _db =  db; 
        }

        private ProductRepository _productRepository;
        private ShopRepository _shopRepository;
        private PurchesOrderRepository _purchesOrderRepository;

        /*public PurchesOrderRepository PurchesOrderRepository =>
            _purchesOrderRepository ?? new PurchesOrderRepository(_db);*/
        public PurchesOrderRepository PurchesOrderRepository
        {
            get
            {
                if (_purchesOrderRepository==null)
                {
                    _purchesOrderRepository= new PurchesOrderRepository(_db);
                }
                return _purchesOrderRepository;
            }
        }


        ProductRepository IUnityOfWork.ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }

        ShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                {
                 _shopRepository = new ShopRepository(_db);
                }

                return _shopRepository;
            }
        }

        public bool SaveChange()
        {
            return _db.SaveChanges() > 0;
        }

        /*public ProductRepository ProductRepository => _productRepository ?? new ProductRepository(_db);*/

    }
}