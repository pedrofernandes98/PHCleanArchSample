using AutoMapper;
using PHCleanArchSample.Application.Dtos;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Application.Mappers
{
    public class DomainToDTOMapingProfile : Profile
    {
        public DomainToDTOMapingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}