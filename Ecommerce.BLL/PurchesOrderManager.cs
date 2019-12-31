using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Contracts;

namespace Ecommerce.BLL
{
    public class PurchesOrderManager:Manager<PurchesOrder>,IPurchesOrderManager
    {
        private IPurchesOrderRepository _orderRepository;
        public PurchesOrderManager(IPurchesOrderRepository purchesOrderRepository):base(purchesOrderRepository)
        {
            _orderRepository = purchesOrderRepository;
        }

    }
}