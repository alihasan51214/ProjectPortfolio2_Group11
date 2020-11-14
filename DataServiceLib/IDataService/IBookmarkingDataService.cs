﻿using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IBookmarkingDataService
    {
        IList<BookmarkPerson> GetBookmarkList();
        BookmarkPerson GetBookMark(int userid,string nconst);
        void CreateBookmark(BookmarkPerson bookmarkPerson);
        bool UpdateBookmark(BookmarkPerson bookmarkPerson);
        bool DeleteBookmark(int userId,string nconst);
    }
}