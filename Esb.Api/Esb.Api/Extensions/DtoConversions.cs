using Esb.Api.Entities;
using Esb.Models.Dtos;

namespace Esb.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<HouseDto> ConvertToDto(this IEnumerable<House> houses)
        {
            return (from house in houses
                    select new HouseDto
                    {
                        ObjectId = house.ObjectId,
                        Code = house.Code,
                        Street = house.Street,
                        Number = house.Number,
                        Addition = house.Addition,
                        ZipCode = house.ZipCode,
                        City = house.City,
                        Country = house.Country,
                        ExternalCode = house.ExternalCode,
                        Customer = house.Customer,
                        YearBuild = house.YearBuild,
                        Daeb = house.Daeb,
                        Latitude = house.Latitude,
                        Longitude = house.Longitude,
                        Complexes = (ICollection<ComplexDto>)house.Complexes.ConvertToDto(),
                        ServiceContracts = (ICollection<ServiceContractDto>)house.ServiceContracts.ConvertToDto(),
                        Documents = (ICollection<DocumentDto>)house.Documents.ConvertToDto(),
                        Images = (ICollection<ImageDto>)house.Images.ConvertToDto(),
                        Serviceorders = (ICollection<ServiceorderDto>)house.Serviceorders.ConvertToDto(),
                    }).ToList();
        }

        public static HouseDto ConvertToDto(this House house)
        {
            return new HouseDto
            {
                ObjectId = house.ObjectId,
                Code = house.Code,
                Street = house.Street,
                Number = house.Number,
                Addition = house.Addition,
                ZipCode = house.ZipCode,
                City = house.City,
                Country = house.Country,
                ExternalCode = house.ExternalCode,
                Customer = house.Customer,
                YearBuild = house.YearBuild,
                Daeb = house.Daeb,
                Latitude = house.Latitude,
                Longitude = house.Longitude,
                Complexes = (ICollection<ComplexDto>)house.Complexes.ConvertToDto(),
                ServiceContracts = (ICollection<ServiceContractDto>)house.ServiceContracts.ConvertToDto(),
                Documents = (ICollection<DocumentDto>)house.Documents.ConvertToDto(),
                Images = (ICollection<ImageDto>)house.Images.ConvertToDto(),
                Serviceorders = (ICollection<ServiceorderDto>)house.Serviceorders.ConvertToDto(),
            };
        }

        public static IEnumerable<ComplexDto> ConvertToDto(this IEnumerable<Complex> complexes)
        {
            return (from complex in complexes
                    select new ComplexDto
                    {
                        ComplexId = complex.ComplexId,
                        Name = complex.Name,
                        Description = complex.Description,
                    }).ToList();
        }

        public static ComplexDto ConvertToDto(this Complex complex)
        {
            return new ComplexDto
            {
                ComplexId = complex.ComplexId,
                Name = complex.Name,
                Description = complex.Description,
            };
        }

        public static IEnumerable<ServiceContractDto> ConvertToDto(this IEnumerable<ServiceContract> serviceContracts)
        {
            return (from serviceContract in serviceContracts
                    select new ServiceContractDto
                    {
                        ServiceContractId = serviceContract.ServiceContractId,
                        Name = serviceContract.Name,
                        Description = serviceContract.Description,
                    }).ToList();
        }

        public static ServiceContractDto ConvertToDto(this ServiceContract serviceContract)
        {
            return new ServiceContractDto
            {
                ServiceContractId = serviceContract.ServiceContractId,
                Name = serviceContract.Name,
                Description = serviceContract.Description,
            };
        }

        public static IEnumerable<DocumentDto> ConvertToDto(this IEnumerable<Document> documents)
        {
            return (from document in documents
                    select new DocumentDto
                    {
                        DocumentId = document.DocumentId,
                        URL = document.URL,
                        ExternalURL = document.ExternalURL,
                        Description = document.Description
                    }).ToList();
        }

        public static DocumentDto ConvertToDto(this Document document)
        {
            return new DocumentDto
            {
                DocumentId = document.DocumentId,
                URL = document.URL,
                ExternalURL = document.ExternalURL,
                Description = document.Description
            };
        }

        public static IEnumerable<ImageDto> ConvertToDto(this IEnumerable<Image> images)
        {
            return (from image in images
                    select new ImageDto
                    {
                        ImageId = image.ImageId,
                        URL = image.URL,
                        ExternalURL = image.ExternalURL,
                        Description = image.Description,
                        Thumbnail = image.Thumbnail,
                    }).ToList();
        }

        public static ImageDto ConvertToDto(this Image image)
        {
            return new ImageDto
            { 
                ImageId = image.ImageId,
                URL = image.URL,
                ExternalURL = image.ExternalURL,
                Description = image.Description,
                Thumbnail = image.Thumbnail,
            };
        }

        public static IEnumerable<ServiceorderDto> ConvertToDto(this IEnumerable<Serviceorder> serviceorders)
        {
            return (from serviceorder in serviceorders
                    select new ServiceorderDto
                    {
                        ServiceorderId = serviceorder.ServiceorderId,
                        ServiceorderNo = serviceorder.ServiceorderNo,
                        Description = serviceorder.Description,
                        Customer = serviceorder.Customer,
                        OrderManager = serviceorder.OrderManager,
                        OrderSoort = serviceorder.OrderSoort,
                        Status = serviceorder.Status,
                        CustomerReference = serviceorder.CustomerReference,
                        OrderType = serviceorder.OrderType,
                        StartingDate = serviceorder.StartingDate,
                        EndDate = serviceorder.EndDate,
                    }).ToList();
        }

        public static ServiceorderDto ConvertToDto(this Serviceorder serviceorder)
        {
            return new ServiceorderDto
            {
                ServiceorderId = serviceorder.ServiceorderId,
                ServiceorderNo = serviceorder.ServiceorderNo,
                Description = serviceorder.Description,
                Customer = serviceorder.Customer,
                OrderManager = serviceorder.OrderManager,
                OrderSoort = serviceorder.OrderSoort,
                Status = serviceorder.Status,
                CustomerReference = serviceorder.CustomerReference,
                OrderType = serviceorder.OrderType,
                StartingDate = serviceorder.StartingDate,
                EndDate = serviceorder.EndDate,
            };
        }
    }
}
