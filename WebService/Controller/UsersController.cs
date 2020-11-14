using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public UsersController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dataService.UsersDS.GetUser(id);
            return Ok(user);
        }

        [HttpPost()]
        public IActionResult CreateUsers(UsersDto dto)
        {
            _dataService.UsersDS.CreateUser(dto.Name, dto.Age, dto.Language, dto.Mail);
            var response = " user created";
            return CreatedAtRoute(null, dto.Name + response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id, UsersDto dto)
        {
            var user =_dataService.UsersDS.DeleteUser(id);
            var response = " user not found";

            if (!user)
            {
                return NotFound(response);
            }
            response = " user deleted";
            return CreatedAtRoute(null, dto.Name + response);
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