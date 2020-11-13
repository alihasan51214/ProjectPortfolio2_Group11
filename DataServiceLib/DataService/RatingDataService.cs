using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib.DataService
{
    public class RatingDataService : IRatingDataService
    {
        private readonly Raw11Context _db;

        public RatingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<UserNameRate> GetRating()
        {
            return _db.UserNameRates.ToList();
        }

        public UserNameRate GetRating(int userid, int nameindividrating, string nconst, DateTime dateTime)
        {
            return _db.UserNameRates.FirstOrDefault(x => x.UserId == userid && 
                                                        x.NameIndividRating == nameindividrating && x.Nconst == nconst); 
        }
        
        public void CreateRating(UserNameRate usernamerate)
        {
            var maxId = _db.UserNameRates.Max(x => x.UserId);
            usernamerate.UserId = maxId + 1;   // for adding +1 amounts of ratings , each time the CreateRating is called.
            _db.UserNameRates.Add(usernamerate);
        }

        public bool UpdateRating(UserNameRate usernamerate)
        {
            var dbRating = GetRating(usernamerate.UserId, usernamerate.NameIndividRating, usernamerate.Nconst, usernamerate.DateTime);
            if (dbRating == null)
            {
                return false;
            }
            dbRating.UserId = usernamerate.UserId;
            dbRating.NameIndividRating = usernamerate.NameIndividRating;
            dbRating.Nconst = usernamerate.Nconst;
            return true;
        }
    }
}