using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib
{
    class Data
    {
        
        public static List<User> Users { get; set; }

        static Data()
        {
            Users = new List<User>
            {
                new User {Id = 1, Name = "Test User", Username = "testing"}
            };
        }
    }
}