using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IRatingDataService
    {
        IList<UserNameRate> GetRatingList();
        UserNameRate GetRating(int userId, string nConst);
        void CreateRating(UserNameRate userNameRate);
        bool UpdateRating(int userId, string nConst, UserNameRate userNameRate);
        bool DeleteRating(int userId, string nConst);
    }
}