using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Models.EntityModels;

namespace Ecommerce.Models.ViewModels.Web.Product
{
    public class ProductCreateVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name!")]
        public string Name { get; set; }

        [StringLength(11)]
        public string Code { get; set; }
        public double Price { get; set; }

        public string WarehouseLocation { get; set; }

        [NotMapped]
        public List<EntityModels.Product> Products {get;set;}

    }
}