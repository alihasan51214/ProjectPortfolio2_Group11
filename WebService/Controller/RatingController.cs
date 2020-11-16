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
            var userTitleRates = _dataService.RatingDs.GetRatingList();
            return Ok(_mapper.Map<IEnumerable<UserTitleRateDto>>(userTitleRates));
        }

        [HttpGet("{userId}/{tConst}")]
        public IActionResult GetRating(int userId, string tConst)
        {
            var userTitleRate = _dataService.RatingDs.GetRating(userId, tConst);
            if (userTitleRate == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserTitleRateDto>(userTitleRate));
        }
        
        [HttpPost]
        public IActionResult CreateBookmark(UserTitleRateForCreationDto userTitleRateForCreationDto)
        {
            var userTitleRate = _mapper.Map<UserTitleRate>(userTitleRateForCreationDto);
            _dataService.RatingDs.CreateRating(userTitleRate);
            return Ok(userTitleRate);
        }
        
        [HttpPut("{userId}/{tConst}")]
        public IActionResult UpdateRating(int userId, string tConst, UserTitleRateForCreationDto userTitleRateForCreationDto)
        {
            var userTitleRate = _mapper.Map<UserTitleRate>(userTitleRateForCreationDto);
            if (_dataService.RatingDs.UpdateRating(userId, tConst, userTitleRate))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        [HttpDelete("{userId}/{tConst}")]
        public IActionResult DeleteRating(int userId, string tConst)
        {
            var response = " rating not found";
            if (!_dataService.RatingDs.DeleteRating(userId, tConst))
            {
                return NotFound(response);
            }
            response = " rating deleted succesfully";
            return CreatedAtRoute(null, userId + response);
        }
    }
}