using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private DataServiceFacade _dataService;

        public RatingController(DataServiceFacade dataService)
        {
            _dataService = dataService;
        }
        
    }
}