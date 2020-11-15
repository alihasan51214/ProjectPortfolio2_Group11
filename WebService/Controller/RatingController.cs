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
        
        [HttpGet]
        public IActionResult GetRatingList()
        {
            var userNameRates = _dataService.RatingDs.GetRatingList();
            return Ok(_mapper.Map<IEnumerable<UserNameRateDto>>(userNameRates));
        }

        [HttpGet("{userId}/{nConst}")]
        public IActionResult GetRating(int userId, string nConst)
        {
            var userNameRates = _dataService.RatingDs.GetRating(userId, nConst);
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
            _dataService.RatingDs.CreateRating(userNameRate);
            return Created("", userNameRate);
        }
        
        [HttpPut("{userId}/{nConst}")]
        public IActionResult UpdateRating(int userId, string nConst, UserNameRateForCreationDto userNameRateForCreationDto)
        {
            var userNameRate = _mapper.Map<UserNameRate>(userNameRateForCreationDto);
            if (_dataService.RatingDs.UpdateRating(userId, nConst, userNameRate))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        [HttpDelete("{userId}/{nConst}")]
        public IActionResult DeleteRating(int userId, string nConst)
        {
            var response = " rating not found";
            if (!_dataService.RatingDs.DeleteRating(userId, nConst))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        }
    }
}