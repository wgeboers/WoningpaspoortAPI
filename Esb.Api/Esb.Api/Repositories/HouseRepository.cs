using Esb.Api.Data;
using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly EsbDbContext esbDbContext;

        public HouseRepository(EsbDbContext esbDbContext)
        {
            this.esbDbContext = esbDbContext;
        }

        public async Task<House> GetHouse(int id)
        {
            var houses = await esbDbContext.Houses
                .Include(c => c.Complexes)
                .Include(s => s.ServiceContracts)
                .Include(d => d.Documents)
                .Include(i => i.Images)
                .Include(s => s.Serviceorders)
                .ToListAsync();

            var house = houses.Find(a => a.ObjectId.Equals(id));

            return house;
        }

        public async Task<House> GetHouseByCode(string code)
        {
            var houses = await esbDbContext.Houses
                .Include(c => c.Complexes)
                .Include(s => s.ServiceContracts)
                .Include(d => d.Documents)
                .Include(i => i.Images)
                .Include(s => s.Serviceorders)
                .ToListAsync();

            var house = houses.Find(a => a.Code.Equals(code));

            return house;
        }

        public async Task<IEnumerable<House>> GetHouses()
        {
            var houses = await esbDbContext.Houses
                .Include(c => c.Complexes)
                .Include(s => s.ServiceContracts)
                .Include(d => d.Documents)
                .Include(i => i.Images)
                .Include(s => s.Serviceorders)
                .ToListAsync();

            return houses;
        }

        public async Task<House> AddHouse(HouseToAddDto houseToAddDto)
        {
            if (houseToAddDto.Addition != null)
            {
                var result = await this.esbDbContext.Houses.AddAsync(new House
                {
                    Code = houseToAddDto.ZipCode + houseToAddDto.Number + houseToAddDto.Addition,
                    Street = houseToAddDto.Street,
                    Number = houseToAddDto.Number,
                    Addition = houseToAddDto.Addition,
                    ZipCode = houseToAddDto.ZipCode,
                    City = houseToAddDto.City,
                    Country = houseToAddDto.Country,
                    ExternalCode = houseToAddDto.ExternalCode,
                    Customer = houseToAddDto.Customer,
                    YearBuild = houseToAddDto.YearBuild,
                    Daeb = houseToAddDto.Daeb,
                    CreationDate = DateTime.Now,
                    CreatedBy = houseToAddDto.CreatedBy,
                    Active = true
                });

                await this.esbDbContext.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                var result = await this.esbDbContext.Houses.AddAsync(new House
                {
                    Code = houseToAddDto.ZipCode + houseToAddDto.Number,
                    Street = houseToAddDto.Street,
                    Number = houseToAddDto.Number,
                    Addition = houseToAddDto.Addition,
                    ZipCode = houseToAddDto.ZipCode,
                    City = houseToAddDto.City,
                    Country = houseToAddDto.Country,
                    ExternalCode = houseToAddDto.ExternalCode,
                    Customer = houseToAddDto.Customer,
                    YearBuild = houseToAddDto.YearBuild,
                    Daeb = houseToAddDto.Daeb,
                    CreationDate = DateTime.Now,
                    CreatedBy = houseToAddDto.CreatedBy,
                    Active = true
                });

                await this.esbDbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

        //public async Task<House> DeleteHouse(int id)
        //{
        //    var house = await this.esbDbContext.Houses.FindAsync(id);

        //    if (house != null)
        //    {
        //        esbDbContext.Houses.Remove(house);
        //        await esbDbContext.SaveChangesAsync();
        //    }

        //    return house;
        //}
    }
}
