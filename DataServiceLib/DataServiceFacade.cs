using DataServiceLib.DataService;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib
{


    public class DataServiceFacade
    {
        public readonly IBookmarkingDataService BookmarkingDS;
        public readonly IRatingDataService RatingDS;
        public readonly IUsersDataService UsersDS;
        public readonly ISearchDataService SearchDS;
        private List<User> _users = Data.Users;

        public DataServiceFacade(IConfiguration configuration)
        {
            var connStr = configuration.GetSection("connectionString").Value;
            
            BookmarkingDS = new BookmarkingDataService(connStr);
            RatingDS = new RatingDataService(connStr);
            UsersDS = new UsersDataService(connStr);
            SearchDS = new SearchDataService(connStr);
        }

        public User GetUser(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }


        public User CreateUser(string name, string username, string password = null, string salt = null)
        {
            var user = new User
            {
                Id = _users.Max(x => x.Id) + 1,
                Name = name,
                Username = username,
                Password = password,
                Salt = salt
            };
            _users.Add(user);
            return user;
        }

    }
}