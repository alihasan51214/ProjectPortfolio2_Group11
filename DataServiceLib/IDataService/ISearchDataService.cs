using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface ISearchDataService
    {
        SearchHistory GetSearchHistory(int userid);
        void AddToSearchHistory(int userid, string searchInput, DateTime searchTime);
        
    }
}