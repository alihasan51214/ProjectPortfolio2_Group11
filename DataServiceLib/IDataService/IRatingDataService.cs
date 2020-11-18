using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IRatingDataService
    {
        IList<UserTitleRate> GetRatingList(int UserId);
        UserTitleRate GetRating(int userId, string tConst);
        IList<TitleRateDto> CreateRating(UserTitleRate userTitleRate);
         
    }
}