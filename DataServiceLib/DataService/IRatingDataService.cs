using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.DataService
{
    public interface IRatingDataService
    {
        IList<UserNameRate> GetRating();
        UserNameRate GetRating(int userId, int nameIndividRating, string nconst, DateTime dateTime);
        void CreateRating(UserNameRate usernamerate);
        bool UpdateRating(UserNameRate usernamerate);
    }
}