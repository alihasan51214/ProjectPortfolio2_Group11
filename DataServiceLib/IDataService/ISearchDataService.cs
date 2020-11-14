using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface ISearchDataService
    {
        //SearchHistory GetSearchHistory(int userId);
        IList<SearchHistory> AddToSearchHistory(int userId, string searchInput);

        IList<SearchHistory> GetSearchHistory(int userid);
    }
}