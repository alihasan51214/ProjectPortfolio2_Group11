using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/Search")]
    public class SearchController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private const int MaxPageSize = 100;

        public SearchController(DataServiceFacade dataService)
        {
            _dataService = dataService;
        }
        
        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }
        
        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _dataService._genre.GetGenre();
            return Ok(genres);
        }
    }
}