using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Repositories.Contracts
{
    public interface IDocumentRepository
    {
        Task<Document> AddDocument(DocumentToAddDto documentToAddDto, string filePath);
        //Task<Document> DeleteDocument(int id);
        Task<IEnumerable<Document>> GetDocuments();
        Task<Document> GetDocument(int id);
    }
}
