using Esb.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esb.Api.Data
{
    public class EsbDbContext:DbContext
    {
        public EsbDbContext(DbContextOptions<EsbDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
                .HasMany(x => x.Complexes)
                .WithMany(y => y.Houses)
                .UsingEntity<HouseComplex>(
                    j => j.HasOne(m => m.Complex).WithMany(g => g.houseComplexes).IsRequired(),
                    j => j.HasOne(m => m.House).WithMany(g => g.houseComplexes).IsRequired()
                );

            modelBuilder.Entity<House>()
                .HasMany(x => x.Documents)
                .WithMany(y => y.Houses)
                .UsingEntity<HouseDocument>(
                    j => j.HasOne(m => m.Document).WithMany(g => g.houseDocuments).IsRequired(),
                    j => j.HasOne(m => m.House).WithMany(g => g.houseDocuments).IsRequired()
                );

            modelBuilder.Entity<House>()
                .HasMany(x => x.Images)
                .WithMany(y => y.Houses)
                .UsingEntity<HouseImage>(
                    j => j.HasOne(m => m.Image).WithMany(g => g.HouseImages).IsRequired(),
                    j => j.HasOne(m => m.House).WithMany(g => g.HouseImages).IsRequired()
                );

            modelBuilder.Entity<House>()
                .HasMany(x => x.ServiceContracts)
                .WithMany(y => y.Houses)
                .UsingEntity<HouseServiceContract>(
                    j => j.HasOne(m => m.ServiceContract).WithMany(g => g.HouseServiceContracts).IsRequired(),
                    j => j.HasOne(m => m.House).WithMany(g => g.HouseServiceContracts).IsRequired()
                );

            modelBuilder.Entity<House>()
                .HasMany(x => x.Serviceorders)
                .WithMany(y => y.Houses)
                .UsingEntity<HouseServiceorder>(
                    j => j.HasOne(m => m.Serviceorder).WithMany(g => g.HouseServiceorders).IsRequired(),
                    j => j.HasOne(m => m.House).WithMany(g => g.HouseServiceorders).IsRequired()
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Complex> Complexes { get; set; }
        public DbSet<ServiceContract> ServiceContracts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Serviceorder> Serviceorders { get; set; }
        public DbSet<HouseComplex> HouseComplexes { get; set; }
        public DbSet<HouseDocument> HouseDocuments { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }
        public DbSet<HouseServiceContract> HouseServiceContracts { get; set; }
        public DbSet<HouseServiceorder> HouseServiceorders { get; set; }
    }
}
