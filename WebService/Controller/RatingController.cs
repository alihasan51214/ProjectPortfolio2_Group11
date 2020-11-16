using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Authentication.Attributes;
using ProjectPortfolio2_Group11.Model;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController :  ControllerBase
    {
        private readonly DataServiceFacade _dataServiceFacade;
        private readonly IMapper _mapper;

        public RatingController(DataServiceFacade dataServiceFacade, IMapper mapper)
        {
            _dataServiceFacade = dataServiceFacade;
            _mapper = mapper;
        }
        
        [Authorization]
        [HttpGet]
        public IActionResult GetRatingList()
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as UsersForAuth;
                var userTitleRates = _dataServiceFacade.RatingDs.GetRatingList(user.UserId);
                return Ok(_mapper.Map<IEnumerable<UserTitleRateDto>>(userTitleRates));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet("{userId}/{tConst}")]
        public IActionResult GetRating(int userId, string tConst)
        {
            var userTitleRate = _dataServiceFacade.RatingDs.GetRating(userId, tConst);
            if (userTitleRate == null)
            {
                var response = " rating not found";
                return NotFound(response);
            }
            return Ok(_mapper.Map<UserTitleRateDto>(userTitleRate));
        }
        
        [HttpPost("{userId}")]
        public IActionResult CreateRating(UserTitleRateForCreationDto userTitleRateForCreationDto)
        {
            var userTitleRate = _mapper.Map<UserTitleRate>(userTitleRateForCreationDto);
            if (!_dataServiceFacade.RatingDs.CheckRating(userTitleRate))
            { 
                string badrequest = "User has already rated this title";
                return BadRequest(badrequest);
            }
            _dataServiceFacade.RatingDs.CreateRating(userTitleRate);
            return Ok(_dataServiceFacade.RatingDs.CreateRating(userTitleRate).ToList());
        }

        [HttpDelete("{userId}/{tConst}")]
        public IActionResult DeleteRating(int userId, string tConst)
        {
            var response = " rating not found";
            if (!_dataServiceFacade.RatingDs.DeleteRating(userId, tConst))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        }
    }
}