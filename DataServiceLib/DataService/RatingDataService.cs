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
        
        public IList<UserNameRate> GetRatingList()
        {
            return _db.UserNameRates.ToList();
        }
        
        public UserNameRate GetRating(int userId, string nConst)
        {
            return _db.UserNameRates.FirstOrDefault(x => x.UserId == userId
                                                         && x.NConst == nConst); 
        }
        
        public void CreateRating(UserNameRate userNameRate)
        {
            _db.UserNameRates.Add(userNameRate);
            _db.SaveChanges();
        }

        public bool UpdateRating(int userId, string nConst, UserNameRate userNameRate)
        {
            var dbUserNameRate = GetRating(userId, nConst);
            if (dbUserNameRate == null)
            {
                return false;
            }
            _db.Remove(dbUserNameRate);
            _db.Add(userNameRate);
            _db.SaveChanges();
            return true;
        }
        
        public bool DeleteRating(int userId, string nConst)
        {
            var dbUserNameRate = GetRating(userId, nConst);
            if (dbUserNameRate == null)
            {
                return false;
            }
            _db.UserNameRates.Remove(dbUserNameRate);
            _db.SaveChanges();
            return true;
        }
    }
}