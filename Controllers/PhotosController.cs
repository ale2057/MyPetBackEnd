using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyPetBackEnd.Entity.Photos;
using MyPetBackEnd.Entity.Photos.Dto;
using MyPetBackEnd.Services;

namespace MyPetBackEnd.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotosController:ControllerBase
    {
        //[EnableCors]
        [HttpGet]
        [Route("allPhotos")]
        public async Task<ActionResult<List<Photos>>> GetPhotos()
        {
            var function = new ServicePhotos();
            var photoList = await function.GetPhotos();
            return photoList;
        }

        [HttpGet]
        [Route("onePhotos/{id}")]
        public async Task<ActionResult<Photos>> GetOnePhoto(int id)
        {
            var function = new ServicePhotos();
            var photoList = await function.GetOnePhoto(id);
            return photoList;
        }

        [HttpPost]
        [Route("addPhoto")]
        public async Task<long> AddPhoto([FromBody] CreatePhotoDto createPhotosDto)
        {
            var function = new ServicePhotos();
            return await function.AddPhoto(createPhotosDto);

        }

        [HttpPut]
        [Route("updatePhoto/{id}")]
        public async Task<ActionResult> UpdatePhoto(int id, [FromBody] UpdatePhotoDto updatePhotoDto)
        {
            var function = new ServicePhotos();
            await function.UpdatePhoto(id,updatePhotoDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("deletePhoto/{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            var function = new ServicePhotos();
            await function.DeletePhoto(id);
            return NoContent();
        }
    }
}
