using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class ServiceorderRepository : IServiceorderRepository
    {
        private readonly EsbDbContext esbDbContext;

        public ServiceorderRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<Serviceorder> GetServiceorder(int id)
        {
            var serviceorder = await esbDbContext.Serviceorders.FindAsync(id);

            return serviceorder;
        }

        public async Task<IEnumerable<Serviceorder>> GetServiceorders()
        {
            var serviceorders = await esbDbContext.Serviceorders.ToListAsync();

            return serviceorders;
        }

        public async Task<Serviceorder> AddServiceorder(ServiceorderToAddDto serviceorderToAddDto)
        {
            var result = await esbDbContext.Serviceorders.AddAsync(new Serviceorder
            {
                ServiceorderNo = serviceorderToAddDto.ServiceorderNo,
                Description = serviceorderToAddDto.Description,
                Customer = serviceorderToAddDto.Customer,
                OrderManager = serviceorderToAddDto.OrderManager,
                OrderSoort = serviceorderToAddDto.OrderSoort,
                Status = serviceorderToAddDto.Status,
                CustomerReference = serviceorderToAddDto.CustomerReference,
                OrderType = serviceorderToAddDto.OrderType,
                StartingDate = serviceorderToAddDto.StartingDate,
                EndDate = serviceorderToAddDto.EndDate,
            });

            await esbDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<Serviceorder> DeleteServiceorder(int id)
        //{
        //    var serviceorder = await esbDbContext.Serviceorders.FindAsync(id);

        //    if (serviceorder != null)
        //    {
        //        esbDbContext.Serviceorders.Remove(serviceorder);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return serviceorder;
        //}

    }
}
    