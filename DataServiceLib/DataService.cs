using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;

namespace DataServiceLib
{
  public class DataService //: IDataService  
    {    
        private readonly string _connectionString;

        public DataService(string connectionString) 
        {
            _connectionString = connectionString; 
        }


        public static List<Users> Users { get; set; }

        public static List<BookmarkPerson> BookmarkPerson { get; set; }


        private List<BookmarkPerson> _Bookmark = new List<BookmarkPerson>();
        private List<BookmarkPerson> _BookmarkPerson = BookmarkPerson;

        private List<Users> _users = Users;



        public BookmarkPerson GetBookMark(int bookmarkid)
        {

            return BookmarkPerson.FirstOrDefault(x => x.BookMarkid == bookmarkid);
            
        }


        public BookmarkPerson CreateBookmark(string nconst, int userid)
        {
            var bookmarkperson = new BookmarkPerson
            {
                Userid = _BookmarkPerson.Max(x => x.Userid) + 1,
                Nconst = nconst
          

            };
            _BookmarkPerson.Add(bookmarkperson);
            return bookmarkperson;
        }


        public Users CreateUser(int UserId, string name, int age, string language,string mail)
        {
            var user = new Users
            {
                UserId = _users.Max(x => x.UserId) + 1,
                Name = name,
                Age= age,
                Language = language
                , Mail = mail
               
            };
            _users.Add(user);
            return user;
        }

        public Users GetUser(int userid)
        {
            return _users.FirstOrDefault(x => x.UserId == userid);
        }


        /*
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
        */
    }
}