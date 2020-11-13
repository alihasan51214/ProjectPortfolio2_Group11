using System;
using System.Linq;
using DataServiceLib.DBObjects;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib.DataService
{
    public class UsersDataService : IUsersDataService
    {
        private readonly Raw11Context _db;
        
        public UsersDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }

   
        //Users methods
        public Users GetUser(int userid)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == userid);
        }
        
        public void CreateUser(string name, int age, string language, string mail)
        {
            var user = new Users
            {
                UserId = _db.Users.Max(x => x.UserId) + 1,
                Name = name,
                Age = age,
                Language = language,
                Mail = mail
            };
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public bool DeleteUser(int userid)
        {
            var user = GetUser(userid);
            if (user == null) 
            {
                 return false;
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return true;
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }
    }
}