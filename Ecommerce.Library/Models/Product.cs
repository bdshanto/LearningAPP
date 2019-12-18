using System;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Library.Contracts;

namespace Ecommerce.Library.Models
{
    public class Product : IDeleteable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name!")]
        public string Name { get; set; }

        [StringLength(11)]
        public string Code { get; set; }
        public double Price { get; set; }

        public string WarehouseLocation { get; set; }

        public int? ShopId { get; set; }
        public  Shop Shop { get; set; }
         
        public bool IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
