using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.DataService
{
    public interface IBookmarkingDataService
    {
        IList<BookmarkPerson> GetBookmarkPerson();
        BookmarkPerson GetBookMark(int userid, string nconst);
        BookmarkPerson CreateBookmarkPerson(string nconst, int userid);
        bool DeleteBookmarkPerson(string nconst, int userid);
    }
}