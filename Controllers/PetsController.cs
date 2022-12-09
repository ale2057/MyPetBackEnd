using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyPetBackEnd.Entity.Pets;
using MyPetBackEnd.Entity.Pets.Dto;
using MyPetBackEnd.Services;

namespace MyPetBackEnd.Controllers
{
    [ApiController]
    [Route("api/pet")]
    public class PetsController : ControllerBase
    {
        [EnableCors]
        [HttpGet]
        [Route("allPets")]
        public async Task<ActionResult<List<Pets>>> GetPets()
        {
            var function = new ServicePets();
            var petList = await function.GetPets();
            return petList;
        }

        [HttpGet]
        [Route("onePet/{id}")]
        public async Task<ActionResult<Pets>> GetOnePet(int id)
        {
            var function = new ServicePets();
            var petsList = await function.GetOnePet(id);
            return petsList;
        }

        [HttpPost]
        [Route("addPet")]
        public async Task<long> AddPet([FromBody] CreatePetDto createPetDto)
        {
            var function = new ServicePets();
            return await function.AddPet(createPetDto);

        }

        [HttpPut]
        [Route("updatePet/{id}")]
        public async Task<ActionResult> UpdatePet(int id, [FromBody] UpdatePetDto updatePetDto)
        {
            var function = new ServicePets();
            await function.UpdatePet(id, updatePetDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("deletePet/{id}")]
        public async Task<ActionResult> DeletePet(int id)
        {
            var function = new ServicePets();
            await function.DeletePet(id);
            return NoContent();
        }
    }
}
