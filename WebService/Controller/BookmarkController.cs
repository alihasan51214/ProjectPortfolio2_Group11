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
        private readonly DataServiceFacade _dataServiceFacade;
        private readonly IMapper _mapper;
        public BookmarkController(DataServiceFacade dataServiceFacade, IMapper mapper)
        {
            _dataServiceFacade = dataServiceFacade;
            _mapper = mapper;
        }

      

        [HttpGet("{userId}/{nConst}")]
        public IActionResult GetBookmark(int userId,string nConst)
        {
            var response = " bookmark not found";
            var bookmark = _dataServiceFacade.BookmarkingDs.GetBookMark(userId,nConst);
            if (bookmark == null)
            {   
                return NotFound(response);
            }
            return Ok(_mapper.Map<BookmarkPersonDto>(bookmark));
        }

        [HttpPost("{userId}")]
        public IActionResult UpdateBookmark(BookmarkPersonForCreationDto bookmarkPersonForCreationDtoDto)
        {
            var response = " This bookmark already exists for this user";
            var bookmark = _mapper.Map<BookmarkPerson>(bookmarkPersonForCreationDtoDto);
            if (!_dataServiceFacade.BookmarkingDs.CreateBookmark(bookmark))
            {
                return BadRequest(response);
            }
            return Created("", bookmark);
        }
        
        [HttpDelete("{userId}/{nConst}")]
        public IActionResult DeleteBookmark(int userId,string nConst)
        {
            var response = " bookmark not found";
            if (!_dataServiceFacade.BookmarkingDs.DeleteBookmark(userId,nConst))
            {
                return NotFound(response);
            }
            response = " bookmark deleted";
            return CreatedAtRoute(null, userId + response);
        }
    }
}