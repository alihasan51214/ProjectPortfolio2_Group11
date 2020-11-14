using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;
 
using Microsoft.EntityFrameworkCore;

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



            var queery = _db.SearchHistory.FromSqlInterpolated($"select * from string_search({userId},{searchInput}");
         //   _db.SearchHistory.Add();
            _db.SaveChanges();
          /*  return queery
               .ToList(); */


        }

        public void AddToSearchHistory(SearchHistory searchhistory)
        {
            var dbUser = GetSearchHistory(searchhistory.UserId);
           
            dbUser.UserId = searchhistory.UserId;
            dbUser.SearchInput = searchhistory.SearchInput;
            


            _db.SaveChanges();
           // return true;
        }



    }
}