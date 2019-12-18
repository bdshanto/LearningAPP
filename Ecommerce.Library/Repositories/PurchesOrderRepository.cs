using Ecommerce.Library.DatabaseContext;
using Ecommerce.Library.Models;

namespace Ecommerce.Library.Repositories
{
    public class PurchesOrderRepository
    {
        private EcommerceDatabaseContext _db;

        //plambing process
        public PurchesOrderRepository(EcommerceDatabaseContext dbContext)
        {
            _db = dbContext;
        }

        public void Add(PurchesOrder entity)
        {
            _db.PurchesOrders.Add(entity);
        }

        public void Update(PurchesOrder entity)
        {
            _db.PurchesOrders.Add(entity);
        }
    }
}