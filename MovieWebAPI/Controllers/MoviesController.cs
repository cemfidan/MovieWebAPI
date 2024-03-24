using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebAPI.Database;

namespace MovieWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieDal _movieDal;

        public MoviesController(MovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        [HttpGet("getmovies")]
        public IActionResult GetMovies()
        {
            var result = _movieDal.GetAll().ToList();
            return Ok(result);
        }
        [HttpGet("getmovie/{id}")]
        public IActionResult GetMovie(int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            } //and other validations
            var result = _movieDal.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult AddMovie(Movie movie)
        {
            _movieDal.Add(movie);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult UpdateMovie(Movie movie)
        {
            _movieDal.Update(movie);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieDal.Delete(id);
            return Ok();
        }
    }
}
