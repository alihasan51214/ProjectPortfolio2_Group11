﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DataServiceLib.DBObjects;
using System;

namespace DataServiceLib
{
  public class DataService : IDataService  //IDataService is an interface used by the DataService. 
        //All the Create/Get/Update/Delete functions used in this class are made in the interface
    {    
        private readonly string _connectionString;

        public DataService(string connectionString) 
        {
            _connectionString = connectionString; 
        }

 
        public List<BookmarkPerson> _BookmarkPerson = IDataService.BookmarkPerson;
        private List<Users> _users = IDataService.Users;
       public  List<TitleGenres> _Genres = IDataService.TitleGenre;
        public List<UserNameRate> _Rating = IDataService.UserNameRate;

        // what is done is above is  calling each class as an object, because you cannot it call it as a Datatype
        // the new ObjectName() function is not used, because we dont want to create a new object everytime we call it, 
        // we want the same already existing one to be used.

        public IList<UserNameRate> GetRating() 
  // uses IList interface,Represents a non-generic collection of objects that can be individually accessed by index. 
        {
      return _Rating;  // returns the object when calling the GetRating function, 
                       //from the List<ObjectName> as shown above in line 19
        }

        public UserNameRate GetRatings(int Userid, int nameindividrating, string nconst, DateTime DateTime)
        {
            return IDataService.UserNameRate.Where(x => x.UserId == Userid &&
                       x.NameIndividRating == nameindividrating && x.Nconst == nconst).FirstOrDefault();

            //parameters of the Object that needs to be returned
        }


        public void CreateRating(UserNameRate usernamerate)  
          
            // everytime this function is called, 1 new rating is made.
         
        {
            var maxId = _Rating.Max(x => x.UserId);
            usernamerate.UserId = maxId + 1;  
            _Rating.Add(usernamerate);
        }

       

        public bool UpdateRating(UserNameRate usernamerate)
        {
            var dbRating = GetRatings(usernamerate.UserId, usernamerate.NameIndividRating, usernamerate.Nconst, usernamerate.DateTime);
            if (dbRating == null)
            {
                return false;
            }
            dbRating.UserId = usernamerate.UserId;
            dbRating.NameIndividRating = usernamerate.NameIndividRating;
            dbRating.Nconst = usernamerate.Nconst;
            return true;

  //If you try to update a non-existant rating, the function returns false and nothings happens, 
  //otherwise, if not false, it returns true and a rating has been updated.
  
        }


        public IList<TitleGenres> GetGenre()
        {
            return _Genres;
        }

          public TitleGenres GetGenres(string tconst, string genres)
        {

            return IDataService.TitleGenre.Where(x => x.Tconst == tconst &&
                           x.Genres == genres).FirstOrDefault();

        }


        public IList<BookmarkPerson> GetBookmarkPerson()
        {
            return _BookmarkPerson;
        }


        public BookmarkPerson GetBookMark(int userid,string nconst)
        {
         
            return IDataService.BookmarkPerson.Where(x => x.Nconst == nconst &&
                           x.Userid == userid).FirstOrDefault();
  
        }

        public BookmarkPerson CreateBookmarkPerson(string nconst, int userid)
        {
            var bookmarkperson = new BookmarkPerson
            {
                Userid = _BookmarkPerson.Max(x => x.Userid) + 1,
                Nconst = nconst


            };
            _BookmarkPerson.Add(bookmarkperson);
            return bookmarkperson;
        }

        public bool DeleteBookmarkPerson(string nconst, int userid)
        {
            var dbBook = GetBookMark(userid,nconst);
            if (dbBook == null)
            {
                return false;
            }
            _BookmarkPerson.Remove(dbBook);
            return true;
  //If you try to delete a non-existant BookmarkPerson, the function returns false and nothing happens, 
   //otherwise, if not false, it returns true and a BookmarkPerson has been deleted.
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