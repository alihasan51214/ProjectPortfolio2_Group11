using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IRatingDataService
    {
        IList<UserNameRate> GetRatingList();
        UserNameRate GetRating(int userId, int nameIndividRating, string nconst, DateTime dateTime);
        void CreateRating(int nameIndividRating, string nconst, DateTime dateTime);
        bool UpdateRating(UserNameRate usernamerate);
    }
}