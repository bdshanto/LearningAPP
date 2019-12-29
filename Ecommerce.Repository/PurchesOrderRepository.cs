using Ecommerce.DatabaseContext;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.EntityModels;

namespace Ecommerce.Repository
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