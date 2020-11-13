using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.DataService
{
    public interface ISearchDataService
    {
        IList<TitleGenres> GetGenre();
        TitleGenres GetGenres(string tconst, string genres);
    }
}