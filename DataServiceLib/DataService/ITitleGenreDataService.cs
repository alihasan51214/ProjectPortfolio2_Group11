using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.DataService
{
    public interface ITitleGenreDataService
    {
        IList<TitleGenres> GetGenre();
        TitleGenres GetGenres(string tconst, string genres);
    }
}