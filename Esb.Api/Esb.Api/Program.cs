using Esb.Api.Data;
using Esb.Api.Repositories;
using Esb.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<EsbDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EsbConnection"))
);

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IComplexRepository, ComplexRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IServiceContractRepository, ServiceContractRepository>();
builder.Services.AddScoped<IServiceorderRepository, ServiceorderRepository>();
builder.Services.AddScoped<IHouseComplexRepository, HouseComplexRepository>();
builder.Services.AddScoped<IHouseDocumentRepository, HouseDocumentRepository>();
builder.Services.AddScoped<IHouseImageRepository, HouseImageRepository>();
builder.Services.AddScoped<IHouseServiceContractRepository, HouseServiceContractRepository>();
builder.Services.AddScoped<IHouseServiceorderRepository, HouseServiceorderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
