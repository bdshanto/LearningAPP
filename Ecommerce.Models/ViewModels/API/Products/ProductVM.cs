namespace Ecommerce.Models.ViewModels.API.Products
{
    public class ProductVM
    {

        public ProductVM()
        {
            Shop= new ShopVm();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string WareHouseLocation { get; set; }
        public double Price { get; set; }
        public ShopVm Shop { get; set; }


        
        
        
    }

    public class ShopVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        
    }
}