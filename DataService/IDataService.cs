using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib
{
    public interface IDataService
    {
        //ControllerUser createuser, login, logud, deleteuser, 
        //ControllerSearch GetMovies, getGenres, getActors,
        //ControllerRate getRate, updateRate
        //ControllerBookmark AddBookmark, RemoveBookmark

        

        IList<TitleGenres> GetGenres();
        TitleGenres GetGenre();
        IList<TitleBasics> GetTitles();
        TitleBasics GetTitle();
        IList<ActorsKnownForTitles> GetActors();
        ActorsKnownForTitles GetActor();

        bool AddBookmark(int id);
        bool DeleteBookmark(int id);

        bool AddRate(int id);
        bool UpdateRate(UserNameRate userNameRate);
        

    }
}