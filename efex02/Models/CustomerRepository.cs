using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efex02.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private EFCustomerContext context;

        public CustomerRepository(EFCustomerContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }
    }
}
