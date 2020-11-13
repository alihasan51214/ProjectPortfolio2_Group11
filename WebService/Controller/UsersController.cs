using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;

        public UsersController(DataServiceFacade dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(UsersDTO uDto)
        {
            var user = _dataService.Users.GetUser(uDto.UserId);
            return Ok(user);
        }

        [HttpPost()]
        public IActionResult CreateUsers(UsersForCreationDTO ufcDto)
        {
            _dataService.Users.CreateUser(ufcDto.Name, ufcDto.Age, ufcDto.Language, ufcDto.Mail);
            var response = " user created";
            return CreatedAtRoute(null, ufcDto.Name + response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(UsersDTO uDto)
        {
            var user =_dataService.Users.DeleteUser(uDto.UserId);
            var response = " user not found";

            if (!user)
            {
                return NotFound(response);
            }
            response = " user deleted";
            return CreatedAtRoute(null, uDto.Name + response);
        }
        /*
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UsersForCreationDTO ufcDto)
        {
            _dataService.Users.CreateUser(ufcDto.Name, ufcDto.Age, ufcDto.Language, ufcDto.Mail);

            if (!_dataService.UpdateCategory(category))
            {
                return NotFound();
            }

            return NoContent();
        }*/
    }
}