using STEAM.Models.Photos;
using STEAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace STEAM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet]
        public async Task<List<GetPhotoDTO>> GetPhotos()
        {
            return await _photosService.GetPhotos();
        }

        [HttpGet("{id}")]
        public async Task<GetPhotoDTO?> GetPhoto(int id)
        {
            return await _photosService.GetPhoto(id);
        }

        [HttpPost]
        public async Task PostPhoto(AddPhotoDTO photo)
        {
            await _photosService.AddPhoto(photo);
        }

        [HttpPut]
        public async Task PutPhoto(UpdatePhotoDTO photo)
        {
            await _photosService.UpdatePhoto(photo);
        }

        [HttpDelete("{id}")]
        public async Task DeletePhoto(int id)
        {
            await _photosService.DeletePhoto(id);
        }
    }
}