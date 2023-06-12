using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class ServiceContractRepository : IServiceContractRepository
    {
        private readonly EsbDbContext esbDbContext;

        public ServiceContractRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<ServiceContract> GetServiceContract(int id)
        {
            var serviceContract = await esbDbContext.ServiceContracts.FindAsync(id);

            return serviceContract;
        }

        public async Task<IEnumerable<ServiceContract>> GetServiceContracts()
        {
            var serviceContracts = await esbDbContext.ServiceContracts.ToListAsync();

            return serviceContracts;
        }

        public async Task<ServiceContract> AddServiceContract(ServiceContractToAddDto serviceContractToAddDto)
        {
            var result = await this.esbDbContext.ServiceContracts.AddAsync(new ServiceContract
            {
                Name = serviceContractToAddDto.Name,
                Description = serviceContractToAddDto.Description,
                CreationDate = DateTime.Now,
                CreatedBy = serviceContractToAddDto.CreatedBy,
            });
            await this.esbDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<ServiceContract> DeleteServiceContract(int id)
        //{
        //    var serviceContract = await this.esbDbContext.ServiceContracts.FindAsync(id);

        //    if (serviceContract != null)
        //    {
        //        esbDbContext.ServiceContracts.Remove(serviceContract);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return serviceContract;
        //}
    }
}
