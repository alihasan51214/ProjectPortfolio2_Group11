using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IBookmarkingDataService
    {
        BookmarkPerson GetBookMark(int userId,string nConst);
        void CreateBookmark(BookmarkPerson bookmarkPerson);
        bool UpdateBookmark(int userId, string nConst, BookmarkPerson bookmarkPerson);
        bool DeleteBookmark(int userId,string nConst);
    }
}