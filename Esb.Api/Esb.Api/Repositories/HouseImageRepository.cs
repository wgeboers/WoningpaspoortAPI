using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;

namespace Esb.Api.Repositories
{
    public class HouseImageRepository : IHouseImageRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseImageRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<HouseImage> AddHouseImage(Image image, House house)
        {
            var result = await this.esbDbContext.HouseImages.AddAsync(new HouseImage
            {
                Image = image,
                House = house,
            });

            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
