using System.Collections.Generic;

namespace Ecommerce.Models.EntityModels
{
    public class PurchesOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string RefNo { get; set; }
        public ICollection<PurchesOrderItem> OrderItems{ get; set; }
      

      
    }
}