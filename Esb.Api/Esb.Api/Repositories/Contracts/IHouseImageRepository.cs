using Esb.Api.Entities;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseImageRepository
    {
        Task<HouseImage> AddHouseImage(Image image, House house);
    }
}
