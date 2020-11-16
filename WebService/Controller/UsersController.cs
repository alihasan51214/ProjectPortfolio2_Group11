using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataServiceFacade _dataServiceFacade;
        private readonly IMapper _mapper;

        public UsersController(DataServiceFacade dataServiceFacade, IMapper mapper)
        {
            _dataServiceFacade = dataServiceFacade;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _dataServiceFacade.UsersDs.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsersDto>(user));
        }
        
        [HttpPost("post")]
        public IActionResult CreateUsers(UsersForCreationDto usersForCreationDto)
        {
            var user = _mapper.Map<Users>(usersForCreationDto);
            _dataServiceFacade.UsersDs.CreateUser(user);
            return Created("", user);
        }
        
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, UsersForCreationDto usersForCreationDto)
        {
            var user = _mapper.Map<Users>(usersForCreationDto);
            if (_dataServiceFacade.UsersDs.UpdateUser(userId, user))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var response = " user not found";
            if (!_dataServiceFacade.UsersDs.DeleteUser(userId))
            {
                return NotFound(response);
            }
            response = " user deleted";
            return CreatedAtRoute(null, userId + response);
        }
    }
}