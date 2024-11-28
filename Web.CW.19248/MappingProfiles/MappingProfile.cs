using AutoMapper;
using Web.CW._19248.DTOs;
using Web.CW._19248.Models;

namespace Web.CW._19248.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.Category.Type));
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
