using STEAM.Database;
using STEAM.Database.Entities;
using Microsoft.EntityFrameworkCore;
using STEAM.Models.Photos;
using AutoMapper;

namespace STEAM.Services
{
    public interface IPhotosService
    {
        Task<List<GetPhotoDTO>> GetPhotos();
        Task<GetPhotoDTO?> GetPhoto(int id);
        Task AddPhoto(AddPhotoDTO photo);
        Task UpdatePhoto(UpdatePhotoDTO photo);
        Task DeletePhoto(int id);
    }

    public class PhotosService : IPhotosService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public PhotosService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetPhotoDTO>> GetPhotos()
        {
            var result = await _dbContext.Photos.ToListAsync();

            return result.Select(x => _mapper.Map<GetPhotoDTO>(x)).ToList();
        }

        public async Task<GetPhotoDTO?> GetPhoto(int id)
        {
            var result = await _dbContext.Photos.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<GetPhotoDTO>(result);
        }

        public async Task AddPhoto(AddPhotoDTO photo)
        {
            var entity = _mapper.Map<Photo>(photo);
            await _dbContext.Photos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePhoto(UpdatePhotoDTO photo)
        {
            var entity = await _dbContext.Photos.FirstOrDefaultAsync(x => x.Id == photo.Id);

            if (entity == null)
            {
                return;
            }
            _mapper.Map(photo, entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePhoto(int id)
        {
            var entity = await _dbContext.Photos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return;
            }

            _dbContext.Photos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
