using AutoMapper;
using PHCleanArchSample.Application.Commands;
using PHCleanArchSample.Application.Dtos;

namespace PHCleanArchSample.Application.Mappers
{
    public class DTOToRequestsMapProfile : Profile
    {
        public DTOToRequestsMapProfile()
        {
            CreateMap<ProductDto, CreateProductCommand>().ReverseMap();
            CreateMap<ProductDto, UpdateProductCommand>().ReverseMap();
        }
        
    }
}
