namespace Ecommerce.Models.EntityModels
{
    public class PurchesOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
        public Product Product { get; set; }
        public PurchesOrder Order { get; set; }
        
        

    }
}