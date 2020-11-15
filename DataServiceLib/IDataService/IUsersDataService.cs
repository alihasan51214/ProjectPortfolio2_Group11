using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IUsersDataService
    {
        Users GetUser(int userId);
        void CreateUser(Users user);
        bool UpdateUser(int userId, Users user);
        bool DeleteUser(int userId);
        bool Login();
        bool Logout();
    }
}