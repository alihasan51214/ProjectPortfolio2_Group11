using DataServiceLib.DataService;
using DataServiceLib.DBObjects;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib
{
    public class DataServiceFacade
    {
        public readonly IBookmarkingDataService _bookmarking;
        public IRatingDataService _rating;
        public readonly IUsersDataService _users;
        public readonly ITitleGenreDataService _genre;
        
        public DataServiceFacade(IConfiguration configuration)
        {
            var connStr = configuration.GetSection("connectionString").Value;
            _bookmarking = new BookmarkingDataService(connStr);
            _rating = new RatingDataService(connStr);
            _users = new UsersDataService(connStr);
            _genre = new TitleGenreDataService(connStr);
        }
    }
}