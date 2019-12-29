using System;
using Ecommerce.Models.Contracts;

namespace Ecommerce.Models.EntityModels
{
    public class Customer:IDeleteable
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public bool IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
