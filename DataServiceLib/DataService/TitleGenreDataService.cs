using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib.DataService
{
    public class TitleGenreDataService : ITitleGenreDataService
    {
        private readonly Raw11Context _db;
        
        public TitleGenreDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<TitleGenres> GetGenre()
        {
            return _db.Genres
                .ToList();
        }

        public TitleGenres GetGenres(string tconst, string genres)
        {
            return _db.Genres.FirstOrDefault(x => x.Tconst == tconst &&
                                                 x.Genres == genres);
        }
    }
}