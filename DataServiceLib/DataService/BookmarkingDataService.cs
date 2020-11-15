using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class BookmarkingDataService : IBookmarkingDataService
    {
        private readonly Raw11Context _db;
        
        public BookmarkingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }

        public BookmarkPerson GetBookMark(int userId, string nConst)
        {
            return _db.BookmarkPerson.FirstOrDefault(x => x.UserId==userId 
                                                          && x.NConst == nConst);
        }

        public void CreateBookmark(BookmarkPerson bookmarkPerson)
        { 
            _db.BookmarkPerson.Add(bookmarkPerson);
            _db.SaveChanges();
        }

        public bool UpdateBookmark(int userId, string nConst, BookmarkPerson bookmarkPerson)
        {
            var dbBook = GetBookMark(userId, nConst);
            if (dbBook == null)
            {
                return false;
            }
            _db.Remove(dbBook);
            _db.Add(bookmarkPerson);
            _db.SaveChanges();
            return true;
        }
        
        public bool DeleteBookmark(int userId, string nConst)
        {
            var dbBook = GetBookMark(userId,nConst);
            if (dbBook == null)
            {
                return false;
            }
            _db.BookmarkPerson.Remove(dbBook);
            _db.SaveChanges();
            return true;
        }
    }
}