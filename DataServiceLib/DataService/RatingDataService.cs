using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class RatingDataService : IRatingDataService
    {
        private readonly Raw11Context _db;

        public RatingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<UserTitleRate> GetRatingList()
        {
            return _db.UserTitleRates.ToList();
        }
        
        public UserTitleRate GetRating(int userId, string tConst)
        {
            return _db.UserTitleRates.FirstOrDefault(x => x.UserId == userId
                                                         && x.TConst == tConst); 
        }
        
        public void CreateRating(UserTitleRate userTitleRate)
        {
            //var queery = _db..FromSqlInterpolated($"select * from rate({userid},{tconst},{rate})");
            _db.UserTitleRates.Add(userTitleRate);
            _db.SaveChanges();
        }

        public bool UpdateRating(int userId, string tConst, UserTitleRate userTitleRate)
        {
            var dbUserNameRate = GetRating(userId, tConst);
            if (dbUserNameRate == userTitleRate)
            {
                return false;
            }
            _db.Add(userTitleRate);
            _db.SaveChanges();
            return true;
        }
        
        public bool DeleteRating(int userId, string tConst)
        {
            var dbUserTitleRate = GetRating(userId, tConst);
            if (dbUserTitleRate == null)
            {
                return false;
            }
            _db.UserTitleRates.Remove(dbUserTitleRate);
            _db.SaveChanges();
            return true;
        }
    }
}