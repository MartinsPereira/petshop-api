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

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<ListCustomerResponseDto>>>> GetAllCustomers()
        {
            var result = await customerService.GetAllCustomers();

            return HandleNotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CreateCustomerResponseDto>>> GetCustomerById(int id)
        {
            var result = await customerService.GetCustomerById(id);

            return HandleNotFound(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<CreateCustomerResponseDto>>> CreateCustomer([FromBody] CreateCustomerRequestDto customer)
        {
            var result = await customerService.CreateCustomer(customer);

            return HandleResult<CreateCustomerResponseDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<CreateCustomerResponseDto>>> UpdateCustomer(int id, [FromBody] CreateCustomerRequestDto customer)
        {
            var result = await customerService.UpdateCustomer(id, customer);

            return HandleResult<CreateCustomerResponseDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<object?>>> DeleteCustomer(int id)
        {
            var result = await customerService.DeleteCustomer(id);

            return HandleResult<object?>(result);
        }
    }
}
