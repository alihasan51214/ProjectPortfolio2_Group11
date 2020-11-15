
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
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;

        public SearchController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }


        [HttpGet("{userid}")]

        // uses userid and nconst as the URL path

        public IActionResult GetSearchHistory(int userid)
        {
            var search = _dataService.SearchDS.GetSearchHistory(userid);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }

        [HttpPost("{userid}")]

        public IActionResult AddToSearchHistory(SearchHistoryDTO searchDTO)
        {
            var search = _dataService.SearchDS.AddToSearchHistory(searchDTO.UserId, searchDTO.SearchInput);

            // var response = " search created succesfully";
            return Ok(search);
            //  return CreatedAtRoute(null,search);
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
