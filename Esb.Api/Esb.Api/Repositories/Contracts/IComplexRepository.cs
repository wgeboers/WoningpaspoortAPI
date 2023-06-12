using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IComplexRepository
    {
        Task<Complex> AddComplex(ComplexToAddDto complexToAddDto);
        //Task<Complex> DeleteComplex(int id);
        Task<IEnumerable<Complex>> GetComplexes();
        Task<Complex> GetComplex(int id);
    }
}
