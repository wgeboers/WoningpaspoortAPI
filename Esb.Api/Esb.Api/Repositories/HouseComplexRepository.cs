using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories
{
    public class HouseComplexRepository : IHouseComplexRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseComplexRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<HouseComplex> AddHouseComplex(Complex complex, House house)
        {
            var result = await this.esbDbContext.HouseComplexes.AddAsync(new HouseComplex
            {
                Complex = complex,
                House = house,
            });

            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
