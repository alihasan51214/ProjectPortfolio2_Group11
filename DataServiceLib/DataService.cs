using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DataServiceLib.DBObjects;
using System;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib
{
  public class DataService : IDataService  
    {
        private readonly string connStr;
        private readonly Raw11Context db;
        
        public DataService(IConfiguration configuration)
        {
            connStr = configuration.GetSection("connectionString").Value;
            db = new Raw11Context(connStr);
        }
        
        //Users methods
        public Users GetUser(int userid)
        {
            return db.Users.FirstOrDefault(x => x.UserId == userid);
        }

        public Users CreateUser(string name, int age, string language,string mail)
        {
            var user = new Users
            {
                UserId = db.Users.Max(x => x.UserId) + 1,
                Name = name,
                Age= age,
                Language = language,
                Mail = mail
            };
            db.Users.Add(user);
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
            return db.UserNameRates.ToList();
        }

        public UserNameRate GetRating(int userid, int nameindividrating, string nconst, DateTime dateTime)
        {
            return db.UserNameRates.FirstOrDefault(x => x.UserId == userid && 
                                                                 x.NameIndividRating == nameindividrating && x.Nconst == nconst); 
        }
        
        public void CreateRating(UserNameRate usernamerate)
        {
            var maxId = db.UserNameRates.Max(x => x.UserId);
            usernamerate.UserId = maxId + 1;   // for adding +1 amounts of ratings , each time the CreateRating is called.
            db.UserNameRates.Add(usernamerate);
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
            return db.BookmarkPerson.ToList();
        }
        
        public BookmarkPerson GetBookMark(int userid,string nconst)
        {
         
            return db.BookmarkPerson.FirstOrDefault(x => x.Nconst == nconst &&
                                                                   x.Userid == userid);
        }
        
        public BookmarkPerson CreateBookmarkPerson(string nconst, int userid)
        {
            var bookmarkperson = new BookmarkPerson
            {
                Userid = db.BookmarkPerson.Max(x => x.Userid) + 1,
                Nconst = nconst
            };
            db.BookmarkPerson.Add(bookmarkperson);
            return bookmarkperson;
        }

        public bool DeleteBookmarkPerson(string nconst, int userid)
        {
            var dbBook = GetBookMark(userid,nconst);
            if (dbBook == null)
            {
                return false;
            }
            db.BookmarkPerson.Remove(dbBook);
            return true;
        }
        
        
        
        //TitleGenre methods

        public IList<TitleGenres> GetGenre()
        {
            return db.Genres
                .ToList();
        }

        public TitleGenres GetGenres(string tconst, string genres)
        {
            return db.Genres.FirstOrDefault(x => x.Tconst == tconst &&
                                                               x.Genres == genres);
        }
  }
}