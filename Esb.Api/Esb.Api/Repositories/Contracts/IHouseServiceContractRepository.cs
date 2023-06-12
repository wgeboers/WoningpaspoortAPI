using Esb.Api.Entities;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseServiceContractRepository
    {
        Task<HouseServiceContract> AddHouseServiceContract(ServiceContract serviceContract, House house);
    }
}
