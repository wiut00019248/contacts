using AutoMapper;

namespace Web.CW._19248.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Models.Contact, Dtos.ContactDto>();
            CreateMap<Dtos.ContactDto, Models.Contact>();
            CreateMap<Models.Category, Dtos.CategoryDto>();
            CreateMap<Dtos.CategoryDto, Models.Category>();
        }
    }
}
