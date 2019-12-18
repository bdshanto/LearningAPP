using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Ecommerce.Library.Models
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