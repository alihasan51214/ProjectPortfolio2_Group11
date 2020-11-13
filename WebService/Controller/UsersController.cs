﻿using DataServiceLib;
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

        [HttpGet("getuser")]
        public IActionResult GetUser(UsersDTO uDto)
        {
            var user = _dataService._users.GetUser(uDto.UserId);
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult CreateUsers(UsersForCreationDTO ufcDto)
        {
            _dataService._users.CreateUser(ufcDto.Name, ufcDto.Age, ufcDto.Language, ufcDto.Mail);
            var response = " user succesfully created";
            return CreatedAtRoute(null, ufcDto.Name + response);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(UsersDTO uDto)
        {
            var user =_dataService._users.DeleteUser(uDto.UserId);
            var response = " user not found";

            if (!user)
            {
                return NotFound(response);
            }
            response = " user deleted succesfully";
            return CreatedAtRoute(null, uDto.Name + response);
        }
    }
}