using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseComplexRepository
    {
        Task<HouseComplex> AddHouseComplex(Complex complex, House house);
    }
}
