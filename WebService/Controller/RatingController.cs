using System.Collections.Generic;
using System.Linq;
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
        private readonly DataServiceFacade _dataServiceFacade;
        private readonly IMapper _mapper;

        public RatingController(DataServiceFacade dataServiceFacade, IMapper mapper)
        {
            _dataServiceFacade = dataServiceFacade;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetRatingList()
        {
            var userTitleRates = _dataServiceFacade.RatingDs.GetRatingList();
            return Ok(_mapper.Map<IEnumerable<UserTitleRateDto>>(userTitleRates));
        }

        [HttpGet("{userId}/{tConst}")]
        public IActionResult GetRating(int userId, string tConst)
        {
            var userTitleRate = _dataServiceFacade.RatingDs.GetRating(userId, tConst);
            if (userTitleRate == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserTitleRateDto>(userTitleRate));
        }
        
        [HttpPost("{userId}")]
        public IActionResult CreateRating(UserTitleRateForCreationDto userTitleRateForCreationDto)
        {
            var userTitleRate = _mapper.Map<UserTitleRate>(userTitleRateForCreationDto);
            if (_dataServiceFacade.RatingDs.CheckRating(userTitleRate))
            {
                return NotFound();
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