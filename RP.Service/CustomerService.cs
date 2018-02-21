using RP.Data;
using RP.Repo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Customer> GetAll()
        {
            return repository.Get();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return repository.GetAsync();
        }

        public Customer GetCustomer(Guid id)
        {
            return repository.GetEntity(id);
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            return repository.GetEntityAsync(id);
        }

        public Guid Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            repository.Update(customer);
            unitOfWork.Commit();
            return customer.Id;
        }

        public Guid Insert(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            repository.Add(customer);
            unitOfWork.Commit();
            return customer.Id;
        }
    }
}