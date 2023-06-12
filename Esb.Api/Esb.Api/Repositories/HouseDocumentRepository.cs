using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;

namespace Esb.Api.Repositories
{
    public class HouseDocumentRepository : IHouseDocumentRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseDocumentRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<HouseDocument> AddHouseDocument(Document document, House house)
        {
            var result = await this.esbDbContext.HouseDocuments.AddAsync(new HouseDocument
            {
                Document = document,
                House = house,
            });

            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
