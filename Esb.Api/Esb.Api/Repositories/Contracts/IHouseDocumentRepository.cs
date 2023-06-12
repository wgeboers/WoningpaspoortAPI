using Esb.Api.Entities;

namespace Esb.Api.Repositories.Contracts
{
    public interface IHouseDocumentRepository
    {
        Task<HouseDocument> AddHouseDocument(Document document, House house);
    }
}
