using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IRatingDataService
    {
      //  IList<UserNameRate> GetRatingList(int userid);

        IList<RatingTable> CreateRating(int userid, string nconst, int rate);

         //UserNameRate GetRating(int userId);
       // void CreateRating(UserNameRate userNameRate);
      /*  bool UpdateRating(UserNameRate userNameRate);
        bool DeleteRating(int userId);*/
    }
}