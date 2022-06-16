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

        public MoviesController(IMovieRepository _context) //Dependency Injection. Injector IMovieRepository.
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
                                                                   // Kalder Repo og lægger det i en ny variabel som er en liste af Movie.
                if (result == null)
                {
                    return StatusCode(500); //Hvis variabel er null, returner intern serverfejl (500)
                }

                if (result.Count == 0) //Hvis der ingen movies er, returner 204 (no Content)
                {
                    return NoContent();
                }

                else
                {
                    return Ok(result); //ellers ok
                }

            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex);
            }
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest(); //Hvis input er 0, returner 400(bad request)
            } 

            try
            {
                var movie = await context.GetMovieByID(id); //Ellers tag input og læg i ny variabel (movie).

                if (movie == null) //Hvis movie er null)
                {
                    return NotFound(); //Returner 404.
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
                List<Movie> result = await context.GetMoviesFrontPage(); //Kalder movie repo. og lægger det i en ny variabel (result) som er en liste af movies.

                if (result == null) //Hvis resultatet er null, returnerer den internal server error (500).
                {
                    return StatusCode(500);
                }

                if (result.Count == 0)
                {
                    return NoContent(); //Hvis det totale resultat er 0, er der ingenting i og man får statuskode NoContent (204)
                }

                else
                {
                    return Ok(result); //Ellers OK (200)
                }
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex); //400
            }
        }

        [HttpGet("GetEntireMovie/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetEntireMovie(int id) 
        {
            try
            {
                var result = await context.GetEntireMovie(id); //Kalder Repo og lægger resultatet i en ny variabel.

                if (result == null) //Hvis resultatet er null, returner internal server error (500).
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
                return (ActionResult)BadRequest(ex);
            }
        }

        [HttpGet("GetMoviesAndActors")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMoviesAndActors()
        {
            try
            {
                List<Movie> result = await context.GetAllMoviesAndActors(); // Ok kan typecast 99% af alt kode whoo! //Kalder Movie Repo.

                if (result == null)
                {
                    return StatusCode(500); //Hvis resultatet er null, får man statuskode 500, som er intern serverfejl.
                }

                if (result.Count == 0) //Hvis det totale resultat er 0, er der ingenting i og man får statuskode NoContent (204)
                {
                    return NoContent();
                }

                else
                { 
                    return Ok(result); //ellers 200.
                } 
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex); //
            }
        }

        //Vores put kan currently kun tilføje fx actors, og ikke fjerne nogle der allerede er tilføjet. Den skal ændres i fremtiden...
        //Vi kan enten ændre denne, så vi fjerner alle actors på movie, og tilføjer kun dem som vi kommer med i json
        //ellers kan vi have en anden controller, så vi bevarer denne, og tilføjer en som gør det ovenstående

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie) //Rediger Movie

        {
            if (id == 0)
            {
                return BadRequest(); //Hvis ID er 0, returnerer den statuskode 400 (Bad Request)
            } 
            try
            {
                if (id != movie.MovieID) //Hvis id der sendes med i URL ikke er identisk med det ID som sendes med i movie objektet giver det status 400.
                    return BadRequest("ID Mismatch");

                var movieToUpdate = await context.GetMovieByID(id); //Kalder GetMovieByID og lægger resultatet i variablen movieToUpdate

                if (movieToUpdate == null) 
                { 
                    return NotFound($"Movie with ID = {id} not found"); //Hvis den nye variabel er null (Der findes ingen film med det ID der sendes med)
                                                                        //Returnerer den statuskode 404 (Not found)
                }

                var result = await context.UpdateMovie(movie);  //Her kalder den UpdateMovie og lægger resultatet i en ny variabel. Movie objektet sendes med.

                if (result != null) 
                {
                    return Ok(movie); //Hvis resultatet ikke er null, får man OK tilbage
                }
                else
                {
                    return BadRequest("Null i Repo"); //Ellers denne kommentar.
                }
            }
            catch (Exception ex)
            {

                return (ActionResult)BadRequest(ex.Message); //Hvis der sker en error, istedet for at crashe, så giver den en 400 statuskode + fejlbeskeden.
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)  //Create movie.
        {
            if (movie == null)      //Hvis Movie objektet man sender med, er null, får man bad request (400)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateMovie(movie); //Ellers kører den CreateMovie() fra Repo.

                return movie;  
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message); //Hvis der sker en error, istedet for at crashe, så giver den en 400 statuskode + fejlbeskeden.
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (id == 0)        //Hvis ID ikke sendes med eller er null, får man statuskode 400 (Bad request)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteMovieByID(id); // Hvis du sender et ID med, så kalder den repository metoden.
                if (response != null)
                {
                    return Ok(response); //Hvis resultatet != null, får man statuskode OK(200)
                }
                else
                {
                    return NotFound(response); //Ellers statuskode 404(Not Found)
                }

            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message); //Hvis der sker en error, istedet for at crashe, så giver den en 400 statuskode + fejlbeskeden.
            }
        }

        [HttpPost("PostAndPutMovie")]

        public async Task<IActionResult> PostAndPutMovie(Movie movie) // Med Flemmings hjælp :) Når en film skal oprettes, skal det gøres meget specifikt           
                                                                      //Hvis man vil have M-M FKs med.
                                                                      //
                                
        {
            if (movie == null)                                      //Hvis movie objektet er null, får man statuskode 400(Bad Request).
            {
                return BadRequest();
            }
            try
            {
                var response = await context.PostAndPutMovie(movie);      //Kalder repo (PostAndPutMovie) - Først poster den en movie som ikke har nogle FK's
                                                                          //Derefter så PUT den movie og tilføjer FKs.
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
