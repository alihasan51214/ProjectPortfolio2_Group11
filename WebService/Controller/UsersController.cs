using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private IDataService _dataService;

        public UsersController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpPost]
        public IActionResult CreateUsers(UsersForCreationDTO ufcDto)
        { 
            
        }
    }
}