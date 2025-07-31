using AutoMapper;
using Main.Application.DTO.Request;
using Main.Application.DTO.Response;
using Main.Domain.Entity.Identy;
using Main.Domain.Entity.Resource;

namespace Main.Cross.Mapper
{
    public class MappingsProfile : Profile
    {

        public MappingsProfile()
        {

            CreateMap<Authenticate, ResponseDtoAuthenticate>().ReverseMap();

            CreateMap<User, ResponseDtoUser>().ReverseMap();
            CreateMap<User, RequestDtoUser_Insert>().ReverseMap();
            CreateMap<User, RequestDtoUser_Update>().ReverseMap();

            CreateMap<AccessControl, ResponseDtoAccessControl>().ReverseMap();
            CreateMap<AccessControl, RequestDtoAccessControl_Insert>().ReverseMap();
            CreateMap<AccessControl, RequestDtoAccessControl_Update>().ReverseMap();

            CreateMap<Administration, ResponseDtoAdministration>().ReverseMap();
            CreateMap<Administration, RequestDtoAdministration_Insert>().ReverseMap();
            CreateMap<Administration, RequestDtoAdministration_Update>().ReverseMap();

            //CreateMap<Customers, CustomersDto>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();
        }

    }
}
