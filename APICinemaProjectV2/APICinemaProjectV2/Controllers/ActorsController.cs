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
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository context;

        public ActorsController(IActorRepository _context)
        {
            context = _context;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            try
            {
                List<Actor> result = await context.GetAllActors(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var actor = context.GetActorByID(id);

                if (actor == null)
                {
                    return NotFound();
                }

                return await actor;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetActorsAndMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllActorsAndMovies()
        {
            try
            {
                List<Actor> result = await context.GetAllActorsAndMovies(); // Ok kan typecast 99% af alt kode whoo!

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

        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor)
        {
            try
            {
                if (id != actor.ActorID)
                    return BadRequest("ID Mismatch");

                var actorToUpdate = await context.GetActorByID(id);

                if (actorToUpdate == null)
                {
                    return NotFound($"Actor with ID = {id} not found");
                }

                var result = await context.UpdateActor(actor);

                if (result != null)
                {
                    return Ok(actor);
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

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            if (actor == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateActor(actor);

                return actor;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteActorByID(id);
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
