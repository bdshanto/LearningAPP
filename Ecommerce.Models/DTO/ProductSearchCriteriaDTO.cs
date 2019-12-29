using Ecommerce.Models.EntityModels;

namespace Ecommerce.Models.DTO
{
    public class ProductSearchCriteriaDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double FromSalesPrice { get; set; }
        public double ToSalesPrice { get; set; }
        public int ShopId { get; set; } 
        public Shop Shop { get; set; }
        
        
        
        
        
    }
} 