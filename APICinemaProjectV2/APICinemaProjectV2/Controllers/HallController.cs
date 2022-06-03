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
    public class HallController : ControllerBase
    {
        private readonly IHallRepository context;

        public HallController(IHallRepository _context)
        {
            context = _context;
        }

        // GET: api/Halls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hall>>> GetHalls()
        {
            try
            {
                List<Hall> result = await context.GetAllHalls(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Halls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hall>> GetHall(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var hall = context.GetHallByID(id);

                if (hall == null)
                {
                    return NotFound();
                }

                return await hall;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHallsAndMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllHallsAndMovies()
        {
            try
            {
                List<Hall> result = await context.GetAllHallsAndMovies(); // Ok kan typecast 99% af alt kode whoo!

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

        // PUT: api/Halls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHall(int id, Hall hall)
        {
            try
            {
                if (id != hall.HallID)
                    return BadRequest("ID Mismatch");

                var hallToUpdate = await context.GetHallByID(id);

                if (hallToUpdate == null)
                {
                    return NotFound($"Hall with ID = {id} not found");
                }

                var result = await context.UpdateHall(hall);

                if (result != null)
                {
                    return Ok(hall);
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

        // POST: api/Halls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hall>> PostHall(Hall hall)
        {
            if (hall == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateHall(hall);

                return hall;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Halls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteHallByID(id);
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
