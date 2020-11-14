using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.DBObjects;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2_Group11.Model;


namespace ProjectPortfolio2_Group11.Controller
{
    [ApiController]
    [Route("api/bookmark")]
    public class BookmarkController : ControllerBase
    {
        private readonly DataServiceFacade _dataService;
        private readonly IMapper _mapper;
        public BookmarkController(DataServiceFacade dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public IActionResult GetBookMarkList()
        {
            var bookmark = _dataService.BookmarkingDS.GetBookmarkList();
            return Ok(_mapper.Map<IEnumerable<BookmarkPersonDto>>(bookmark));
        }
        
        
    //    [HttpGet("{userid}")]
        [HttpGet("get")]
        public IActionResult GetBookMark(int userid,string nconst)
        {
            var bookmark = _dataService.BookmarkingDS.GetBookMark(userid,nconst);
            if (bookmark == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(bookmark));
        }


        [HttpPost("post")]
        public IActionResult CreateBookmark(BookmarkPersonForCreationDto bookDto)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(bookDto);
            _dataService.BookmarkingDS.CreateBookmark(bookmark);
            return Created("", bookmark);
        }

        
        [HttpPut("{UserId}")]
        public IActionResult UpdateBookmark(int UserId)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(UserId);
            if (_dataService.BookmarkingDS.UpdateBookmark(bookmark))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        
        [HttpDelete("{UserId}")]
        public IActionResult DeleteBookmark(int userid,string nconst)
        {
            var response = " bookmark not found";
            if (!_dataService.BookmarkingDS.DeleteBookmark(userid,nconst))
            {
                return NotFound(response);
            }
            response = " bookmark deleted";
            return CreatedAtRoute(null, userid + response);
        }
    }
}