using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataServiceLib.DataService
{
    public class SearchDataService : ISearchDataService
    {
        private readonly Raw11Context _db;
        
        public SearchDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }

        public IList<SearchHistory> GetSearchHistory(int userId)
        {
            return _db.SearchHistory.Where(x => x.UserId == userId).ToList();
        }

        public IList<TitleBasicsDto> AddToSearchHistory(int page, int pageSize, int userId, string searchInput)
        {
            var queery = _db.TitleBasicsDTO.FromSqlInterpolated($"select primarytitle from string_search({userId},{searchInput})");
            _db.SaveChanges();
             return queery
                 .Skip(page * pageSize)
                 .Take(pageSize)
                 .ToList();
        }
        
        public int NumberOfElements(int userId, string searchInput)
        {
            return _db.TitleBasicsDTO
                .FromSqlInterpolated($"select primarytitle from string_search({userId},{searchInput})").Count();
        }
    }
}