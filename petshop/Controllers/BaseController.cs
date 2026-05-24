using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Petshop.Domain.Common;

namespace Petshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult<Result<T>> HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        protected ActionResult<Result<T>> HandleNotFound<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        protected ActionResult<Result<T>> HandleValidateModel<T>(ActionResult<Result<T>> result)
        {
            if (!ModelState.IsValid)
            {
                var erro = ModelState.Values.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)
                                            .FirstOrDefault() ?? "Algum dos campos está inválido.";

                return BadRequest(Result<string>.Failure(erro));
            }

            return result;
        }
    }
}
