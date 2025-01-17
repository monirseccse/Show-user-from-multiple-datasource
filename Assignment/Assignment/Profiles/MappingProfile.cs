using Assignment.Model.Domain;
using Assignment.Model.ResponseDto;
using AutoMapper;

namespace Assignment.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListOutDto>().ReverseMap();
            CreateMap<User, UserOutDto>().ReverseMap();
        }
    }
}

