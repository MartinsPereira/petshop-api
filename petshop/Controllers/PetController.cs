using Microsoft.AspNetCore.Mvc;
using Petshop.Application.Dtos;
using Petshop.Application.Interfaces;
using Petshop.Domain.Common;

namespace Petshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController(IPetService petshopService) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<PetReponseDto>>>> GetAllPets()
        {
            var result = await petshopService.GetAllPets();
            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<PetReponseDto>>> GetPetById(int id)
        {
            var result = await petshopService.GetPetById(id);

            return HandleNotFound(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<PetReponseDto>>> CreatePet([FromBody] CreatePetRequestDto newPet)
        {
            var result = await petshopService.CreatePet(newPet);

            return HandleValidateModel(HandleResult(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<PetReponseDto>>> UpdatePet(int id, [FromBody] CreatePetRequestDto updatePet)
        {
            var result = await petshopService.UpdatePet(id, updatePet);

            return HandleValidateModel(HandleNotFound(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<PetReponseDto>>> DeletePet(int id)
        {
            var result = await petshopService.DeletePet(id);

            return HandleNotFound(result);
        }
    }
}
