using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using System;
namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IDataService _dataService;
        private const int MaxPageSize = 100;

        public SearchController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }
        
        [HttpGet("get")]
        public IActionResult GetSearch(SearchHistoryDTO searchDTO)
        {
            var search = _dataService.GetSearch(searchDTO.UserId);
            return Ok(search);
            


        }
         
        [HttpPost("newsearch")]
        public IActionResult CreateSearch(string arg)
        {
            _dataService.CreateSearch( arg);
           // _dataService.CreateSearch(searchDTO.UserId, searchDTO.SearchInput, searchDTO.DateTime);
            var response = " search created succesfully";
            return CreatedAtRoute(null, response);
        }
    }
}