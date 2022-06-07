using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICinemaProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTimesController : ControllerBase
    {
        private readonly IMovieTimeRepository context;

        public MovieTimesController(IMovieTimeRepository _context)
        {
            context = _context;
        }

        // GET: api/MovieTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieTime>>> GetMovieTimes()
        {
            try
            {
                List<MovieTime> result = await context.GetAllMovieTimes(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/MovieTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieTime>> GetMovieTime(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var movieTime = context.GetMovieTimeByID(id);

                if (movieTime == null)
                {
                    return NotFound();
                }

                return await movieTime;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEntireMovieTimes")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetEntireMovieTimes()
        {
            try
            {
                var result = await context.GetEntireMovieTimes();

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


        //[HttpGet("GetMovieTimesAndActors")]
        //public async Task<ActionResult<IEnumerable<MovieTime>>> GetAllMovieTimesAndActors()
        //{
        //    try
        //    {
        //        List<MovieTime> result = await context.GetAllMovieTimesAndActors(); // Ok kan typecast 99% af alt kode whoo!

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

        // PUT: api/MovieTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieTime(int id, MovieTime movieTime)
        {
            try
            {
                if (id != movieTime.MovieTimeID)
                    return BadRequest("ID Mismatch");

                var movieTimeToUpdate = await context.GetMovieTimeByID(id);

                if (movieTimeToUpdate == null)
                {
                    return NotFound($"MovieTime with ID = {id} not found");
                }

                var result = await context.UpdateMovieTime(movieTime);

                if (result != null)
                {
                    return Ok(movieTime);
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

        // POST: api/MovieTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieTime>> PostMovieTime(MovieTime movieTime)
        {
            if (movieTime == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateMovieTime(movieTime);

                return movieTime;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/MovieTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieTime(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteMovieTimeByID(id);
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
