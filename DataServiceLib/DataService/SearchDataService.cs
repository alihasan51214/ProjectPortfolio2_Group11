using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class SearchDataService : ISearchDataService
    {
        private readonly Raw11Context _db;
        
        public SearchDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public SearchHistory GetSearchHistory(int userId)
        {
            return _db.SearchHistory.FirstOrDefault(x => x.UserId == userId);
        }

        public void AddToSearchHistory(int userId, string searchInput, DateTime searchTime)
        {
            throw new NotImplementedException();
        }
        
        
    }
}