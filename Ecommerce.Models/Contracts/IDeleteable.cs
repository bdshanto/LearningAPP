using System;

namespace Ecommerce.Models.Contracts
{
    public interface IDeleteable
    {
        bool IsDeleted { get; set; }
        int? DeletedById { get; set; }
        DateTime? DeletedOn { get; set; }
        string DeleteRemarks { get; set; }

    }
}
