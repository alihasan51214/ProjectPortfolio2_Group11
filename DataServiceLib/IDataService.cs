using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib
{
    public interface IDataService
    {
        //ControllerUser createuser, login, logud, deleteuser, 
        //ControllerSearch GetMovies, getGenres, getActors,
        //ControllerRate getRating, UpdateRating
        //ControllerBookmark AddBookmark, RemoveBookmark
         
        IList<TitleGenres> GetGenres();
        TitleGenres GetGenre();
        IList<TitleBasics> GetTitles();
        TitleBasics GetTitle();
        IList<ActorsKnownForTitles> GetActors();
        ActorsKnownForTitles GetActor();

        bool CreateBookmark(int id);
        bool DeleteBookmark(int id);

        bool CreateRating(int id);
        bool UpdateRating(UserNameRate userNameRate);
        

    }
}