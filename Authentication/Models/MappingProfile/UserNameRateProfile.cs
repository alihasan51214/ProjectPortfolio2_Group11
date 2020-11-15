using AutoMapper;
using DataServiceLib.DBObjects;

namespace Authentication.Model.MappingProfile
{
    public class UserNameRateProfile : Profile
    {
        public UserNameRateProfile()
        {
            CreateMap<UserNameRate, UserNameRateDto>();
            CreateMap<UserNameRateForCreationDto, UserNameRate>();
        }
    }
}