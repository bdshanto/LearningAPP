using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Base;
using Ecommerce.Repository.Abstraction.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class PurchesOrderRepository:Repository<PurchesOrder>,IPurchesOrderRepository
    {
        private EcommerceDatabaseContext _dbContext;
        public PurchesOrderRepository(EcommerceDatabaseContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override ICollection<PurchesOrder> GetAll()
        {
            return _dbContext.PurchesOrders
                .Include(c =>c.OrderItems)
              
                .ToList();
        }
    }
}