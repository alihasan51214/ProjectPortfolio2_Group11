using AutoMapper;
using DataServiceLib.DBObjects;

namespace Authentication.Model.MappingProfile
{
    public class BookmarkPersonProfile : Profile
    {
        public BookmarkPersonProfile()
        {
            CreateMap<BookmarkPerson, BookmarkPersonDto>();
            CreateMap<BookmarkPersonForCreationDto, BookmarkPerson>();
        }
    }
}