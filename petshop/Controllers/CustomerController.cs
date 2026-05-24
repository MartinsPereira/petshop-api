using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Dtos.Customer;
using Petshop.Application.Interfaces;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;

namespace Petshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : BaseController
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<Customer>>> GetCustomerById(int id)
        {
            var result = await customerService.GetCustomerById(id);

            return HandleNotFound(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Customer>>> CreateCustomer([FromBody] CreateCustomerRequestDto customer)
        {
            var result = await customerService.CreateCustomer(customer);

            return HandleResult<Customer>(result);
        }
    }
}
