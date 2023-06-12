using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly EsbDbContext esbDbContext;

        public ImageRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<Image> GetImage(int id)
        {
            var image = await esbDbContext.Images.FindAsync(id);

            return image;
        }

        public async Task<IEnumerable<Image>> GetImages()
        {
            var images = await esbDbContext.Images.ToListAsync();

            return images;
        }

        public async Task<Image> AddImage(ImageToAddDto imageToAddDto, string filePath)
        {
            var result = await this.esbDbContext.Images.AddAsync(new Image
            {
                URL = filePath,
                Description = imageToAddDto.Description,
                Thumbnail = imageToAddDto.Thumbnail,
                CreationDate = DateTime.Now,
                CreatedBy = imageToAddDto.CreatedBy,
            });
            await this.esbDbContext.SaveChangesAsync();
            result.Entity.ExternalURL = "https://e47b-37-114-89-117.ngrok-free.app/api/Image/imagefile/" + result.Entity.ImageId;
            await this.esbDbContext.SaveChangesAsync();

            return result.Entity;
        }

        //public async Task<Image> DeleteImage(int id)
        //{
        //    var image = await this.esbDbContext.Images.FindAsync(id);

        //    if (image != null)
        //    {
        //        esbDbContext.Images.Remove(image);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return image;
        //}
    }
}
