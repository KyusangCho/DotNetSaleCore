using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSaleCore.Models
{
    /// <summary>
    /// Repository Class: Dapper 또는 Entity Framework Core로 실제구현 
    /// </summary>
    public class CustomerRepositoryAsync : ICustomerRepositoryAsync
    {
        private readonly DotNetSaleCoreDbContext _context;
        private readonly ILogger _logger;

        public CustomerRepositoryAsync(DotNetSaleCoreDbContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("CustomerRepositoryAsync");
        }

        // 입력
        public async Task<Customer> AddAsync(Customer model)
        {
            _context.Add(model);
            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (Exception exp)
            {

                _logger.LogError($"Error in {nameof(AddAsync)}: " + exp.Message); 
            }
            return model; 
        }

        // 출력 
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.OrderByDescending(c => c.CustomerId)
                //.Include(c => c.Mobile1)
                .ToListAsync(); 
        }

        // 상세
        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Customers
                //.Include(c => c.CustomerId)
                .SingleOrDefaultAsync(c => c.CustomerId == id); 
        }

        // 수정
        public async Task<bool> EditAsync(Customer model)
        {
            _context.Customers.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false); 
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(EditAsync)}: " + exp.Message); 
            }
            return false; 
        }

        // 삭제
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers
                                        .SingleOrDefaultAsync(c => c.CustomerId == id);
            _context.Remove(customer);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteAsync)}: " + ex.Message); 
            }
            return false; 
        }

        // 페이징 
    }
}
