using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;

namespace DataServiceLib
{
  public class DataService
    {    
        private readonly string _connectionString;

        public DataService(string connectionString) 
        {
            _connectionString = connectionString; 
        }
        
        public IList<ActorsKnownForTitles> GetActorsKnownForTitles()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.ActorsKnownForTitles.ToList();
        }

        public IList<ActorsProfession> GetActorsProfession()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.ActorsProfessions.ToList();
        }
        
        public IList<BookmarkPerson> GetBookmarkPerson()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.BookmarkPerson.ToList();
        }

        public IList<Bookmarktitle> GetBookmarktitle()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.Bookmarktitle.ToList();
        }
        
        public IList<Directors> GetDirectors()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.Directors.ToList();
        }

        public IList<NameBasics> GetNameBasics()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.NameBasics.ToList();
        }

        public IList<SearchHistory> GetSearchHistory()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.SearchHistory.ToList();
        }

        public IList<TitleAkas> GetTitleAkas()
        {
            using var ctx = new Raw11Context(_connectionString); 
            return ctx.TitleAkas.ToList();
        }
        
        public IList<TitleBasics> GetTitleBasics()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.TitleBasics.ToList();
        }
        
        public IList<TitlePrincipals> TitlePrincipals()
        {
            using var ctx = new Raw11Context(_connectionString); 
            return ctx.TitlePrincipals.ToList();
        }

        public IList<TitleEpisode> TitleEpisode()
        {
            using var ctx = new Raw11Context(_connectionString); 
            return ctx.EpisodeTitles.ToList();
        }
        
        public IList<TitleGenres> Genres()
        {
            using var ctx = new Raw11Context(_connectionString); 
            return ctx.Genres.ToList();
        }
        
        public IList<UserNameRate> GetUserNameRate()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.UserNameRates.ToList();
        }

        public IList<UserTitleRate> GetUserTitleRate()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.UserTitleRates.ToList();
        }
        
        public IList<Users> GetUsers()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.Users.ToList();
        }

        public IList<WordSearch> GetWordSearch()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.WordSearch.ToList();
        }

        public IList<Writer> GetWriter()
        {
            using var ctx = new Raw11Context(_connectionString);
            return ctx.Writers.ToList();
        }
    }
}