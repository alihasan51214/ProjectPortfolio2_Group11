using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IUsersDataService
    {
        Users GetUser(int userid);
        void CreateUser(string name, int age, string language, string mail);
        bool DeleteUser(int userid);
        bool UpdateUser(Users user);
        bool Login();
        bool Logout();
    }
}