using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IServiceorderRepository
    {
        Task<Serviceorder> AddServiceorder(ServiceorderToAddDto serviceorderToAddDto);
        //Task<Serviceorder> DeleteServiceorder(int id);
        Task<IEnumerable<Serviceorder>> GetServiceorders();
        Task<Serviceorder> GetServiceorder(int id);
    }
}
