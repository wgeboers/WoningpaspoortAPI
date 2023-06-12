using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;

namespace Esb.Api.Repositories
{
    public class HouseServiceContractRepository : IHouseServiceContractRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseServiceContractRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }
        public async Task<HouseServiceContract> AddHouseServiceContract(ServiceContract serviceContract, House house)
        {
            var result = await this.esbDbContext.HouseServiceContracts.AddAsync(new HouseServiceContract
            {
                ServiceContract = serviceContract,
                House = house,
            });

            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
