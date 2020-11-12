using System.Collections.Generic;
using DataServiceLib.DBObjects;
using System;

namespace DataServiceLib
{
    public interface IDataService
    {
        // List of Objects accesible by index. They are static
        // because we dont want to create a new object everytime we call it, we want to use one that already exists
        static List<Users> Users { get; set; }
        Users GetUser(int userid);
        Users CreateUser(string name, int age, string language, string mail);
        bool DeleteUser();
        bool Login();
        bool Logout();
        
        
        static List<UserNameRate> UserNameRate { get; set; }
        IList<UserNameRate> GetRating();
        UserNameRate GetRating(int userId, int nameIndividRating, string nconst, DateTime dateTime);
        void CreateRating(UserNameRate usernamerate);
        bool UpdateRating(UserNameRate usernamerate);

        
        static List<BookmarkPerson> BookmarkPerson { get; set; }
        IList<BookmarkPerson> GetBookmarkPerson();
        BookmarkPerson GetBookMark(int userid, string nconst);
        BookmarkPerson CreateBookmarkPerson(string nconst, int userid);
        bool DeleteBookmarkPerson(string nconst, int userid);
        
        
        static List<TitleGenres> TitleGenre { get; set; }
        IList<TitleGenres> GetGenre();
        TitleGenres GetGenres(string tconst, string genres);
    }
}