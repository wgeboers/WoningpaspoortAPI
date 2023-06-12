using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IServiceContractRepository
    {
        Task<ServiceContract> AddServiceContract(ServiceContractToAddDto serviceContractToAddDto);
        //Task<ServiceContract> DeleteServiceContract(int id);
        Task<IEnumerable<ServiceContract>> GetServiceContracts();
        Task<ServiceContract> GetServiceContract(int id);
    }
}
