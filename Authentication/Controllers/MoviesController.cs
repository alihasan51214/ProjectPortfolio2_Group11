using System;
using System.Linq;
using DataServiceLibrary;
using Microsoft.AspNetCore.Mvc;
using Authentication.Attributes;
using Authentication.Models;

namespace Authentication.Controllers
{
    [ApiController]
    [Route("api/v3/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public MoviesController(IDataService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                var movies = _dataService.GetMovies(user.Id);
                return Ok(movies.Select(CreateMovieDto));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }


        [HttpGet("{movieId}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string movieId)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                var movie = _dataService.GetMovie(1, movieId);
                return Ok(CreateMovieDto(movie));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        /**
         *
         * Helper
         *
         */

        private MovieDto CreateMovieDto(Movie movie)
        {
            return new MovieDto
            {
                Url = Url.Link(nameof(GetMovie), new { movieId = movie.Id }),
                Title = movie.Title,
                Type = movie.Type
            };
        }
    }
}