using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/bookmark")]
    public class BookmarkController : ControllerBase
    {
        private IDataService _dataService;

        public BookmarkController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        
    }
}