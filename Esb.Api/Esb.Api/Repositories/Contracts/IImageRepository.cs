using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IImageRepository
    {
        Task<Image> AddImage(ImageToAddDto imageToAddDto, string filePath);
        //Task<Image> DeleteImage(int id);
        Task<IEnumerable<Image>> GetImages();
        Task<Image> GetImage(int id);
    }
}
