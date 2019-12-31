using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Contracts;

namespace Ecommerce.BLL
{
    public class CustomerManager:Manager<Customer>,ICustomerManager

    {
        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}