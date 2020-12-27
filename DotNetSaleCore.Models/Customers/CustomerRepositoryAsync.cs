using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSaleCore.Models
{
    /// <summary>
    /// Repository Class: Dapper 또는 Entity Framework Core로 실제구현 
    /// </summary>
    public class CustomerRepositoryAsync : ICustomerRepositoryAsync
    {
        public Task<Customer> AddAsync(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
