using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DataServiceLib.DBObjects;
using System;

namespace DataServiceLib
{
  public class DataService : IDataService  
    {
        private readonly List<BookmarkPerson> _bookmarkPerson = IDataService.BookmarkPerson;
        private readonly List<Users> _users = IDataService.Users;
        private readonly List<TitleGenres> _genres = IDataService.TitleGenre;
        private readonly List<UserNameRate> _rating = IDataService.UserNameRate;
        // what is done is above is  calling each class as an object, rather than calling them as a Datatype, which cannot be done
        // the new Objectname() function is not used, because we dont want a new object everytime we call it, we want the same existing one.
        
        
        
        //Users methods
        public Users GetUser(int userid)
        {
            return _users.FirstOrDefault(x => x.UserId == userid);
        }

        public Users CreateUser(string name, int age, string language,string mail)
        {
            var user = new Users
            {
                UserId = _users.Max(x => x.UserId) + 1,
                Name = name,
                Age= age,
                Language = language,
                Mail = mail
            };
            _users.Add(user);
            return user;
        }

        public bool DeleteUser()
        {
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }
        
        
        
        //Rating methods
        public IList<UserNameRate> GetRating()
        {
            return _rating;
        }

        public UserNameRate GetRating(int userid, int nameindividrating, string nconst, DateTime dateTime)
        {
            return IDataService.UserNameRate.FirstOrDefault(x => x.UserId == userid && 
                                                                 x.NameIndividRating == nameindividrating && x.Nconst == nconst); 
        }
        
        public void CreateRating(UserNameRate usernamerate)
        {
            var maxId = _rating.Max(x => x.UserId);
            usernamerate.UserId = maxId + 1;   // for adding +1 amounts of ratings , each time the CreateRating is called.
            _rating.Add(usernamerate);
        }

        public bool UpdateRating(UserNameRate usernamerate)
        {
            var dbRating = GetRating(usernamerate.UserId, usernamerate.NameIndividRating, usernamerate.Nconst, usernamerate.DateTime);
            if (dbRating == null)
            {
                return false;
            }
            dbRating.UserId = usernamerate.UserId;
            dbRating.NameIndividRating = usernamerate.NameIndividRating;
            dbRating.Nconst = usernamerate.Nconst;
            return true;
        }

        
        
        //Bookmarking methods
        public IList<BookmarkPerson> GetBookmarkPerson()
        {
            return _bookmarkPerson;
        }
        
        public BookmarkPerson GetBookMark(int userid,string nconst)
        {
         
            return IDataService.BookmarkPerson.FirstOrDefault(x => x.Nconst == nconst &&
                                                                   x.Userid == userid);
        }
        
        public BookmarkPerson CreateBookmarkPerson(string nconst, int userid)
        {
            var bookmarkperson = new BookmarkPerson
            {
                Userid = _bookmarkPerson.Max(x => x.Userid) + 1,
                Nconst = nconst


            };
            _bookmarkPerson.Add(bookmarkperson);
            return bookmarkperson;
        }

        public bool DeleteBookmarkPerson(string nconst, int userid)
        {
            var dbBook = GetBookMark(userid,nconst);
            if (dbBook == null)
            {
                return false;
            }
            _bookmarkPerson.Remove(dbBook);
            return true;
        }
        
        
        
        //TitleGenre methods
        public IList<TitleGenres> GetGenre()
        {
            return _genres;
        }

        public TitleGenres GetGenres(string tconst, string genres)
        {
            return IDataService.TitleGenre.FirstOrDefault(x => x.Tconst == tconst &&
                                                               x.Genres == genres);
        }
  }
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