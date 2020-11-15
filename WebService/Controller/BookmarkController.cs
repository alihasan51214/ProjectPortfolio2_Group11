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

        [HttpGet("{userId}/{nConst}")]
        public IActionResult GetBookMark(int userId,string nConst)
        {
            var bookmark = _dataService.BookmarkingDs.GetBookMark(userId,nConst);
            if (bookmark == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(bookmark));
        }
        
        [HttpPost("{userId}")]
        public IActionResult CreateBookmark(BookmarkPersonForCreationDto bookmarkPersonForCreationDto)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(bookmarkPersonForCreationDto);
            _dataService.BookmarkingDs.CreateBookmark(bookmark);
            return Created("", bookmark);
        }
        
        [HttpPut("{userId}/{nConst}")]
        public IActionResult UpdateBookmark(int userId, string nConst, BookmarkPersonForCreationDto bookmarkPersonForCreationDtoDto)
        {
            var bookmark = _mapper.Map<BookmarkPerson>(bookmarkPersonForCreationDtoDto);
            if (_dataService.BookmarkingDs.UpdateBookmark(userId, nConst, bookmark))
            {
                return NotFound();
            }
            return NoContent();
        }
        
        [HttpDelete("{userId}/{nConst}")]
        public IActionResult DeleteBookmark(int userId,string nConst)
        {
            var response = " bookmark not found";
            if (!_dataService.BookmarkingDs.DeleteBookmark(userId,nConst))
            {
                return NotFound(response);
            }
            response = " bookmark deleted";
            return CreatedAtRoute(null, userId + response);
        }
    }
}