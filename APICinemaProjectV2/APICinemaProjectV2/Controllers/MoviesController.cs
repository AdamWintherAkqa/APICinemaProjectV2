using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICinemaProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository context;

        public MoviesController(IMovieRepository _context)
        {
            context = _context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                List<Movie> result = await context.GetAllMovies(); // Ok kan typecast 99% af alt kode whoo!
                if (result == null)
                {
                    return StatusCode(500);
                }

                if (result.Count == 0)
                {
                    return NoContent();
                }

                else
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return (ActionResult)StatusCode(500, ex);
            }
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var movie = await context.GetMovieByID(id);

                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        //[HttpGet("GetMoviesAndHalls")]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetAllHallsAndMovies()
        //{
        //    try
        //    {
        //        List<Movie> result = await context.GetAllMoviesAndHalls(); // Ok kan typecast 99% af alt kode whoo!

        //        if (result == null)
        //        {
        //            return StatusCode(500);
        //        }

        //        if (result.Count == 0)
        //        {
        //            return NoContent();
        //        }

        //        else
        //        {
        //            return Ok(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (ActionResult)StatusCode(500, ex);
        //    }
        //}

        [HttpGet("GetMoviesFrontPage")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesFrontPage()
        {
            try
            {
                List<Movie> result = await context.GetMoviesFrontPage();

                if (result == null)
                {
                    return StatusCode(500);
                }

                if (result.Count == 0)
                {
                    return NoContent();
                }

                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return (ActionResult)StatusCode(500, ex);
            }
        }

        [HttpGet("GetEntireMovie/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetEntireMovie(int id)
        {
            try
            {
                var result = await context.GetEntireMovie(id);

                if (result == null)
                {
                    return StatusCode(500);
                }

                //if (result.Count == 0)
                //{
                //    return NoContent();
                //}

                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return (ActionResult)StatusCode(500, ex);
            }
        }

        [HttpGet("GetMoviesAndActors")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMoviesAndActors()
        {
            try
            {
                List<Movie> result = await context.GetAllMoviesAndActors(); // Ok kan typecast 99% af alt kode whoo!

                if (result == null)
                {
                    return StatusCode(500);
                }

                if (result.Count == 0)
                {
                    return NoContent();
                }

                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return (ActionResult)StatusCode(500, ex);
            }
        }

        //Vores put kan currently kun tilføje fx actors, og ikke fjerne nogle der allerede er tilføjet. Den skal ændres i fremtiden...
        //Vi kan enten ændre denne, så vi fjerner alle actors på movie, og tilføjer kun dem som vi kommer med i json
        //ellers kan vi have en anden controller, så vi bevarer denne, og tilføjer en som gør det ovenstående

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            try
            {
                if (id != movie.MovieID)
                    return BadRequest("ID Mismatch");

                var movieToUpdate = await context.GetMovieByID(id);

                if (movieToUpdate == null)
                {
                    return NotFound($"Movie with ID = {id} not found");
                }

                var result = await context.UpdateMovie(movie);

                if (result != null)
                {
                    return Ok(movie);
                }
                else
                {
                    return BadRequest("Null i Repo");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateMovie(movie);

                return movie;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteMovieByID(id);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }

            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpPost("PostAndPutMovie")]

        public async Task<IActionResult> PostAndPutMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.CreateMovie(movie); 
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }

            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }
    }
}
