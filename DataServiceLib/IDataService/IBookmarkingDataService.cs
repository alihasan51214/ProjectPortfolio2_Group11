using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IBookmarkingDataService
    {
        IList<BookmarkPerson> GetBookmarks();
        BookmarkPerson GetBookMark(int userId,string nConst);
        bool CreateBookmark(BookmarkPerson bookmarkPerson);
        bool DeleteBookmark(int userId,string nConst);
    }
}