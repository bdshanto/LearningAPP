using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Library.Contracts;

namespace Ecommerce.Library.Models
{
    public class Shop:IDeleteable
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public Shop()
        {
            Products = new List<Product>();
        }


        public bool IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
    }
}
