using DotNetSaleCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DotNetSaleCore.Apis.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly ILogger _logger;

        public CustomersController(ICustomerRepositoryAsync customerRepository, ILoggerFactory loggerFactory)
        {
            this._customerRepository = customerRepository;
            this._logger = loggerFactory.CreateLogger(nameof(CustomersController));
        }

        // GET api/Customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                return Ok(customers); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(); 
            }
        }

        // GET api/Customers/1/10
        [HttpGet("Page/{skip}/{take}")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            try
            {
                var customersSet = await _customerRepository.GetAllAsync(skip, take);

                // 응답 헤더에 총 레코드 수를 담아서 출력 
                Response.Headers.Add("X-TotalRecordCount", customersSet.totalRecords.ToString()); 

                return Ok(customersSet.Records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // GET api/Customers/1
        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(id); 
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // POST api/Customers
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            try
            {
                var newCustomer = await _customerRepository.AddAsync(customer); 
                if (newCustomer == null)
                {
                    return BadRequest(); 
                }
                return CreatedAtRoute("GetCustomerById", new { id = newCustomer.CustomerId }); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(); 
            }

        }

        // PUT api/Customers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            try
            {
                var status = await _customerRepository.EditAsync(customer); 
                if (!status)
                {
                    return BadRequest(); 
                }
                return Ok(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(); 
            }
        }

        // DELETE api/Customers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var status = await _customerRepository.DeleteAsync(id); 
                if (!status)
                {
                    return BadRequest(); 
                }
                return Ok(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(); 
            }
        }
    }
}
