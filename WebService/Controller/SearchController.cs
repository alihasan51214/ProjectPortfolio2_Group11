using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/Search")]
    public class SearchController : ControllerBase
    {
        private IDataService _dataService;

        public SearchController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _dataService.GetGenre();

            return Ok(genres);
        }
    }
}