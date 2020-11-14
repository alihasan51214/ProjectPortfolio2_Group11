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
        
        public SearchHistory GetSearchHistory(int userid)
        {
            return _db.SearchHistory.FirstOrDefault(x => x.UserId == userid);
        }

        public void AddToSearchHistory(int userid, string searchInput, DateTime searchTime)
        {
            throw new NotImplementedException();
        }
    }
}