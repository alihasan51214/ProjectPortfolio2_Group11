using DataServiceLib.DataService;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib
{
    public class DataServiceFacade
    {
        public readonly IBookmarkingDataService Bookmarking;
        public readonly IRatingDataService Rating;
        public readonly IUsersDataService Users;
        public readonly ISearchDataService Search;
        
        public DataServiceFacade(IConfiguration configuration)
        {
            var connStr = configuration.GetSection("connectionString").Value;
            
            Bookmarking = new BookmarkingDataService(connStr);
            Rating = new RatingDataService(connStr);
            Users = new UsersDataService(connStr);
            Search = new SearchDataService(connStr);
        }
    }
}