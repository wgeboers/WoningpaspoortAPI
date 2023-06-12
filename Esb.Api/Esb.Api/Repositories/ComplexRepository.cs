using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class ComplexRepository : IComplexRepository
    {
        private readonly EsbDbContext esbDbContext;

        public ComplexRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<Complex> GetComplex(int id)
        {
            var complex = await esbDbContext.Complexes.FindAsync(id);

            return complex;
        }

        public async Task<IEnumerable<Complex>> GetComplexes()
        {
            var complexes = await esbDbContext.Complexes.ToListAsync();

            return complexes;
        }

        public async Task<Complex> AddComplex(ComplexToAddDto complexToAddDto)
        {
            var result = await this.esbDbContext.Complexes.AddAsync(new Complex
                                                                    {
                                                                        Name = complexToAddDto.Name,
                                                                        Description = complexToAddDto.Description,
                                                                        CreationDate = DateTime.Now,
                                                                        CreatedBy = complexToAddDto.CreatedBy,
                                                                    });
            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<Complex> DeleteComplex(int id)
        //{
        //    var complex = await this.esbDbContext.Complexes.FindAsync(id);

        //    if (complex != null)
        //    {
        //        esbDbContext.Complexes.Remove(complex);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return complex;
        //}
    }
}
