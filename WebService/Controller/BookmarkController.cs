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
        
        
        [HttpGet("{id}")]
        public IActionResult GetBookMark(int userId)
        {
            var bookmark = _dataService.BookmarkingDS.GetBookMark(userId);
            if (bookmark == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(bookmark));
        }

        
        [HttpPost]
        public IActionResult CreateBookmark(BookmarkPersonForCreationDto bookDto)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(bookDto);
            _dataService.BookmarkingDS.CreateBookmark(bookmark);
            return Created("", bookmark);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateBookmark(int userId)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(userId);
            if (_dataService.BookmarkingDS.UpdateBookmark(bookmark))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int userId)
        {
            var response = " bookmark not found";
            if (!_dataService.BookmarkingDS.DeleteBookmark(userId))
            {
                return NotFound(response);
            }
            response = " bookmark deleted";
            return CreatedAtRoute(null, userId + response);
        }
    }
}