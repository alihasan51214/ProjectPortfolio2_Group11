using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/bookmark")]
    public class BookmarkController : ControllerBase
    {
        private readonly IDataService _dataService;

        public BookmarkController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("getbookmark")]
        public IActionResult GetBookMark(BookmarkPersonDTO bookDto)
        {
            var bookmark = _dataService.GetBookMark(bookDto.Userid, bookDto.Nconst);
            return Ok(bookmark);
        }

        [HttpPost("createbookmark")]
        public IActionResult CreateBookmarkPerson(BookmarkPersonDTO bookDto)
        {
            _dataService.CreateBookmarkPerson(bookDto.Nconst, bookDto.Userid);
            var response = " user succesfully created";
            return CreatedAtRoute(null, bookDto.Userid + bookDto.Nconst + response);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBookmarkPerson(BookmarkPersonDTO bookDto)
        {
            var bookmark = _dataService.DeleteBookmarkPerson(bookDto.Nconst, bookDto.Userid);
            var response = " bookmark not found";

            if (!bookmark)
            {
                return NotFound(response);
            }

            if (!bookmark)
            {
                return NotFound(response);
            }

            response = " bookmark deleted succesfully";
            return CreatedAtRoute(null, bookDto.Userid + response);
        }
    }
}