using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDataService _dataService;

        public UsersController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpPost("register")]
        public IActionResult CreateUsers(UsersForCreationDTO ufcDto)
        {
            _dataService.CreateUser(ufcDto.Name, ufcDto.Age, ufcDto.Language, ufcDto.Mail);
            return CreatedAtRoute(null, new {ufcDto.Name, ufcDto.Age, ufcDto.Language, ufcDto.Mail});
        }
    }
}