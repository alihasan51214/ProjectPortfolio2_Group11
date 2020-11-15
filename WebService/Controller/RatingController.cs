using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public RatingController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
      

        [HttpPost("{userid}")]
        public IActionResult CreateRating(UserTitleRate usertitleatedto)
        {
        
        // var userNameRate = _mapper.Map<UserNameRate>(userNameRateForCreationDto);
        var usernamerate=  _dataService.RatingDS.CreateRating(usertitleatedto.UserId, usertitleatedto.Tconst, usertitleatedto.TitleIndividRating);
            return Ok(usernamerate);
        }


      
        
       /* [HttpPut("{id}")]
        public IActionResult UpdateRating(int userid)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userid);
            if (_dataService.RatingDS.UpdateRating(userNameRate))
            {
                return NotFound();
            }
            return NoContent();
        } */
        
        
      /*  [HttpDelete("{id}")]
        public IActionResult DeleteRating(int userId)
        {
            var response = " rating not found";
            if (!_dataService.RatingDS.DeleteRating(userId))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        } */
    }
}