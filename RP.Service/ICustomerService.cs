using RP.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();

        Task<List<Customer>> GetAllAsync();

        Guid Insert(Customer customer);

        Customer GetCustomer(Guid id);

        Task<Customer> GetCustomerAsync(Guid id);

        Guid Update(Customer customer);
    }
}