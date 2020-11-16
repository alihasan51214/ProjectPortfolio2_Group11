using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IRatingDataService
    {
        IList<UserTitleRate> GetRatingList();
        UserTitleRate GetRating(int userId, string tConst);
        void CreateRating(UserTitleRate userTitleRate);
        bool UpdateRating(int userId, string tConst, UserTitleRate userTitleRate);
        bool DeleteRating(int userId, string tConst);
    }
}