using Microsoft.AspNetCore.Mvc;
using pract6.Data;
using pract6.Models;

namespace pract6.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MoviesController : Controller
    {
        static WebApiDatabaseContext DbCon = new WebApiDatabaseContext();

        [HttpGet]
        public IActionResult GetAll(string? genre, int? minYear)
        {
            var movieList = DbCon.Movies.AsQueryable();

            if (genre != null)
            {
                movieList = movieList.Where(m => m.Genre == genre);
            }

            if (minYear != null)
            {
                movieList = movieList.Where(m => m.ReleaseYear >= minYear);
            }

            return Ok(movieList.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Movie movie = DbCon.Movies.Find(id);

            if (id <= 0)
            {
                return BadRequest();
            }

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            DbCon.Movies.Add(movie);
            DbCon.SaveChanges();
            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Movie movie)
        {
            Movie oldMovie = DbCon.Movies.Find(id);

            if (id <= 0)
            {
                return BadRequest();
            }

            if (oldMovie == null)
            {
                return NotFound();
            }

            oldMovie.Title = movie.Title;
            oldMovie.Genre = movie.Genre;
            oldMovie.DurationMinutes = movie.DurationMinutes;
            oldMovie.ReleaseYear = movie.ReleaseYear;
            oldMovie.IsAvailable = movie.IsAvailable;

            DbCon.SaveChanges();

            return Ok(oldMovie);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] System.Text.Json.JsonElement patch)
        {
            Movie movie = DbCon.Movies.Find(id);

            if (id <= 0)
            {
                return BadRequest();
            }

            if (movie == null)
            {
                return NotFound();
            }

            if (patch.TryGetProperty("title", out var title))
            {
                movie.Title = title.GetString();
            }

            if (patch.TryGetProperty("genre", out var genre))
            {
                movie.Genre = genre.GetString();
            }

            if (patch.TryGetProperty("durationMinutes", out var durationMinutes))
            {
                movie.DurationMinutes = durationMinutes.GetInt32();
            }

            if (patch.TryGetProperty("releaseYear", out var releaseYear))
            {
                movie.ReleaseYear = releaseYear.GetInt32();
            }

            if (patch.TryGetProperty("isAvailable", out var isAvailable))
            {
                movie.IsAvailable = isAvailable.GetBoolean();
            }

            DbCon.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Movie movie = DbCon.Movies.Find(id);

            if (id <= 0)
            {
                return BadRequest();
            }

            if (movie == null)
            {
                return NotFound();
            }

            DbCon.Movies.Remove(movie);
            DbCon.SaveChanges();

            return NoContent();
        }
    }
}