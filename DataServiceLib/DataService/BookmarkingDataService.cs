using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib.DataService
{
    public class BookmarkingDataService : IBookmarkingDataService
    {
        private readonly Raw11Context _db;
        
        public BookmarkingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<BookmarkPerson> GetBookmarkPerson()
        {
            return _db.BookmarkPerson.ToList();
        }
        
        public BookmarkPerson GetBookMark(int userid,string nconst)
        {
         
            return _db.BookmarkPerson.FirstOrDefault(x => x.Nconst == nconst &&
                                                         x.Userid == userid);
        }
        
        public BookmarkPerson CreateBookmarkPerson(string nconst, int userid)
        {
            var bookmarkperson = new BookmarkPerson
            {
                Userid = _db.BookmarkPerson.Max(x => x.Userid) + 1,
                Nconst = nconst
            };
            _db.BookmarkPerson.Add(bookmarkperson);
            return bookmarkperson;
        }

        public bool DeleteBookmarkPerson(string nconst, int userid)
        {
            var dbBook = GetBookMark(userid,nconst);
            if (dbBook == null)
            {
                return false;
            }
            _db.BookmarkPerson.Remove(dbBook);
            return true;
        }
    }
}