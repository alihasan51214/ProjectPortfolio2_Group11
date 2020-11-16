
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;

namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/Search")]
    public class SearchController : ControllerBase
    {
        private readonly DataServiceFacade _dataServiceFacade;
        private readonly IMapper _mapper;

        public SearchController(DataServiceFacade dataServiceFacade, IMapper mapper)
        {
            _dataServiceFacade = dataServiceFacade;
            _mapper = mapper;
        }
        
        [HttpGet("{userId}")]
        public IActionResult GetSearchHistory(int userId)
        {
            var search = _dataServiceFacade.SearchDs.GetSearchHistory(userId);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }

        [HttpPost("{userId}")]
        public IActionResult AddToSearchHistory(SearchHistoryDto searchDto)
        {
            var search = _dataServiceFacade.SearchDs.AddToSearchHistory(searchDto.UserId, searchDto.SearchInput);
            return Ok(search);
        }

      /*  private BasicsDTO CreateMovieDto(BasicsDTO movie)
        {
            return new BasicsDTO
            {
                Url = Url.Link(nameof(GetMovie), new { movieId = movie.Id }),
                Title = movie.Title,
                Type = movie.Type
            }; */
        }
    }
