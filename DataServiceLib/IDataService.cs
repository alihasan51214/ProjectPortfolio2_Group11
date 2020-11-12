using System.Collections.Generic;
using DataServiceLib.DBObjects;
using System;

namespace DataServiceLib
{
    public interface IDataService
    {
        Users GetUser(int userid);
        Users CreateUser(string name, int age, string language, string mail);
        bool DeleteUser();
        bool Login();
        bool Logout();
        
        
        IList<UserNameRate> GetRating();
        UserNameRate GetRating(int userId, int nameIndividRating, string nconst, DateTime dateTime);
        void CreateRating(UserNameRate usernamerate);
        bool UpdateRating(UserNameRate usernamerate);

        
        IList<BookmarkPerson> GetBookmarkPerson();
        BookmarkPerson GetBookMark(int userid, string nconst);
        BookmarkPerson CreateBookmarkPerson(string nconst, int userid);
        bool DeleteBookmarkPerson(string nconst, int userid);
        
        
        IList<TitleGenres> GetGenre();
        TitleGenres GetGenres(string tconst, string genres);
        
        
    }
}