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

        public UserNameRate GetRating(int userid, int nameindividrating, string nconst, DateTime dateTime)
        {
            return _db.UserNameRates.FirstOrDefault(x => x.UserId == userid && 
                                                        x.NameIndividRating == nameindividrating && x.Nconst == nconst); 
        }
        
        public void CreateRating(int nameIndividRating, string nconst, DateTime dateTime)
        {
            var usernamerate = new UserNameRate
            {
                UserId = _db.UserNameRates.Max(x => x.UserId) + 1,
                NameIndividRating = nameIndividRating,
                Nconst = nconst,
                DateTime = dateTime
            };
            _db.UserNameRates.Add(usernamerate);
            _db.SaveChanges();
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
            _db.SaveChanges();
            return true;
        }
    }
}