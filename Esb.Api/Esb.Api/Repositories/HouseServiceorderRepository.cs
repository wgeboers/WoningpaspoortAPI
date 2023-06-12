using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;

namespace Esb.Api.Repositories
{
    public class HouseServiceorderRepository : IHouseServiceorderRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseServiceorderRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<HouseServiceorder> AddHouseServiceorder(Serviceorder serviceorder, House house)
        {
            var result = await this.esbDbContext.HouseServiceorders.AddAsync(new HouseServiceorder
            {
                Serviceorder = serviceorder,
                House = house,
            });

            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
