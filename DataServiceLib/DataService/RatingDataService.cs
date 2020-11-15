using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataServiceLib.DataService
{
    public class RatingDataService : IRatingDataService
    {
        private readonly Raw11Context _db;

        public RatingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<UserNameRate> GetRatingList(int userid)
        {
            return _db.UserNameRates.Where(x => x.UserId == userid).ToList();
        }
         
        public IList<RatingTable> CreateRating(int userid, string tconst, int rate)
        {
              
       var queery = _db.RatingTable.FromSqlInterpolated($"select * from rate({userid},{tconst},{rate})");

            //var queery = _db.TitleBasics.FromSqlInterpolated($"select * from string_search({userId},{searchInput})");

            _db.SaveChanges();
            return queery
                .ToList();
             
        }
           
       /* public bool UpdateRating(UserNameRate userNameRate)
        {
            var dbUserNameRate = GetRating(userNameRate.UserId);
            if (dbUserNameRate == null)
            {
                return false;
            }

            dbUserNameRate.UserId = userNameRate.UserId;
            dbUserNameRate.NameIndividRating = userNameRate.NameIndividRating;
            dbUserNameRate.Nconst = userNameRate.Nconst;
            dbUserNameRate.DateTime = userNameRate.DateTime;
            _db.SaveChanges();
            return true;
        }
        
        public bool DeleteRating(int userId)
        {
            var dbUserNameRate = GetRating(userId);
            if (dbUserNameRate == null)
            {
                return false;
            }
            _db.UserNameRates.Remove(dbUserNameRate);
            _db.SaveChanges();
            return true;
        } */
    }
}