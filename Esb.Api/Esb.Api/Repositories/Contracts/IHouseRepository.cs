using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseRepository
    {
        Task<House> AddHouse(HouseToAddDto HouseToAddDto);
        //Task<House> DeleteHouse(int id);
        Task<IEnumerable<House>> GetHouses();
        Task<House> GetHouse(int id);
        Task<House> GetHouseByCode(string code);
    }
}
