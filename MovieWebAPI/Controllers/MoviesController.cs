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

        [HttpGet]
        public IActionResult GetMovies()
        {
            var result = _movieDal.GetAll().ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovie(int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            } //and other validations
            var result = _movieDal.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            _movieDal.Add(movie);
            return Ok("Movie added");
        }
        [HttpPut]
        public IActionResult UpdateMovie(Movie movie)
        {
            _movieDal.Update(movie);
            return Ok("Movie updated");
        }
        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            _movieDal.Delete(id);
            return Ok("Movie deleted");
        }
    }
}
