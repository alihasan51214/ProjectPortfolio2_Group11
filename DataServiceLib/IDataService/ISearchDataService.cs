using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface ISearchDataService
    {
        IList<TitleBasicsDto> AddToSearchHistory(int page, int pageSize, int userId, string searchInput);
        IList<SearchHistory> GetSearchHistory(int userId);
        public int NumberOfElements(int userId, string searchInput);
    }
}