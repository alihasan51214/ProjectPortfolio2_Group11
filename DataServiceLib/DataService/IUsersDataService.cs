using DataServiceLib.DBObjects;

namespace DataServiceLib.DataService
{
    public interface IUsersDataService
    {
        Users GetUser(int userid);
        void CreateUser(string name, int age, string language, string mail);
        bool DeleteUser(int userid);
        bool Login();
        bool Logout();
    }
}