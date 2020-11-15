using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using Authentication.Model;
using System;
using System.Linq;

namespace Authentication.Controller
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public RatingController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }


        //[HttpGet]
        //public IActionResult GetRatingList()
        //{
        //    try
        //    {
        //        var user = Request.HttpContext.Items["Users"] as User;
        //        var userNameRates = _dataService.RatingDS.GetRatingList(user.Id);
        //        return Ok(_mapper.Map<IEnumerable<UserNameRateDto>>(userNameRates));
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return Unauthorized();

        //    }
        //}

        [HttpGet]
        public IActionResult GetRatings()
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                var ratings = _dataService.RatingDS.GetRatingList(user.Id);
                return Ok(ratings.Select(CreateRatingDto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Unauthorized();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRating(int userId)
        {
            var userNameRates = _dataService.RatingDS.GetRating(userId);
            if (userNameRates == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(userNameRates));
        }


        [HttpPost]
        public IActionResult CreateBookmark(UserNameRateForCreationDto userNameRateForCreationDto)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userNameRateForCreationDto);
            _dataService.RatingDS.CreateRating(userNameRate);
            return Created("", userNameRate);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRating(int userid)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userid);
            if (_dataService.RatingDS.UpdateRating(userNameRate))
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int userId)
        {
            var response = " rating not found";
            if (!_dataService.RatingDS.DeleteRating(userId))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        }
        //changeg
        private UserNameRateDto CreateRatingDto(UserNameRate userNameRate)
        {
            return new UserNameRateDto
            {
                UserId = userNameRate.UserId,
                DateTime = userNameRate.DateTime,
                Nconst = userNameRate.Nconst,
                NameIndividRating = userNameRate.NameIndividRating
            };
        }
    }
}