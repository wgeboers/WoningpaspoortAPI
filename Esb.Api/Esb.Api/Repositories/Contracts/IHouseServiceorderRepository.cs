using Esb.Api.Entities;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseServiceorderRepository
    {
        Task<HouseServiceorder> AddHouseServiceorder(Serviceorder serviceorder, House house);
    }
}
