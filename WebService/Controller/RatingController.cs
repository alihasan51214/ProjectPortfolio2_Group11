using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private IDataService _dataService;

        public RatingController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
    }
}