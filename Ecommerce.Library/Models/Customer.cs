using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ecommerce.Library.Contracts;

namespace Ecommerce.Library.Models
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
