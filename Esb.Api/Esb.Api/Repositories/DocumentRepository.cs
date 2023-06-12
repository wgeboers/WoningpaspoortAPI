using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class DocumentRepository :IDocumentRepository
    {
        private readonly EsbDbContext esbDbContext;

        public DocumentRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<Document> GetDocument(int id)
        {
            var document = await esbDbContext.Documents.FindAsync(id);

            return document;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            var documents = await esbDbContext.Documents.ToListAsync();

            return documents;
        }

        public async Task<Document> AddDocument(DocumentToAddDto documentToAddDto, string filePath)
        {
            var result = await esbDbContext.Documents.AddAsync(new Document
            {
                URL = filePath,
                Description = documentToAddDto.Description,
                CreationDate = DateTime.Now,
                CreatedBy = documentToAddDto.CreatedBy,
            });
            await esbDbContext.SaveChangesAsync();
            result.Entity.ExternalURL = "https://e47b-37-114-89-117.ngrok-free.app/api/Document/documentfile/" + result.Entity.DocumentId;
            await this.esbDbContext.SaveChangesAsync();

            return result.Entity;
        }

        //public async Task<Document> DeleteDocument(int id)
        //{
        //    var document = await esbDbContext.Documents.FindAsync(id);

        //    if (document != null)
        //    {
        //        esbDbContext.Documents.Remove(document);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return document;
        //}
    }
}
