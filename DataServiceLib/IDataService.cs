using System.Collections.Generic;
using DataServiceLib.DBObjects;
    using System;

namespace DataServiceLib
{
    public interface IDataService
    {
        //ControllerUser createuser, login, logud, deleteuser, 
        //ControllerSearch GetMovies, getGenres, getActors,
        //ControllerRate getRating, UpdateRating
        //ControllerBookmark AddBookmark, RemoveBookmark

          IList<TitleGenres> GetGenre();

        IList<UserNameRate> GetRating();
        UserNameRate GetRating(int UserId, int NameIndividRating, string Nconst, DateTime DateTime);
 
        TitleGenres GetGenres(string Tconst, string Genres);
         IList<BookmarkPerson> GetBookmarkPerson();
        public static List<Users> Users { get; set; }  // List of Objects accesible by index. They are static
        // because we dont want to create a new object everytime we call it, we want to use one that already exists

        public static List<UserNameRate> UserNameRate { get; set; }

        public static List<BookmarkPerson> BookmarkPerson { get; set; }

        public static List<TitleGenres> TitleGenre { get; set; }

        bool DeleteBookmarkPerson(string nconst, int userid);

       void CreateRating(UserNameRate usernamerate);
        bool UpdateRating(UserNameRate usernamerate);


        /* IList<TitleBasics> GetTitles();
         TitleBasics GetTitle();
         IList<ActorsKnownForTitles> GetActors();
         ActorsKnownForTitles GetActor(); */


        

    }
}