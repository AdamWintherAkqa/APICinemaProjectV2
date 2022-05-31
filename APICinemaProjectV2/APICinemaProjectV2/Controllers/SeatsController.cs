using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.DAL.Repositories;
using APICinemaProject2.DAL.Repositories;

namespace APICinemaProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatRepository context;

        public SeatsController(ISeatRepository _context)
        {
            context = _context;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            try
            {
                List<Seat> result = await context.GetAllSeats(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var seat = context.GetSeatByID(id);

                if (seat == null)
                {
                    return NotFound();
                }

                return await seat;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            try
            {
                if (id != seat.SeatID)
                    return BadRequest("ID Mismatch");

                var seatToUpdate = await context.GetSeatByID(id);

                if (seatToUpdate == null)
                {
                    return NotFound($"Seat with ID = {id} not found");
                }

                var result = await context.UpdateSeat(seat);

                if (result != null)
                {
                    return Ok(seat);
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

        // POST: api/Seats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            if (seat == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateSeat(seat);

                return seat;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteSeatByID(id);
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
        public List<String> ConvertDates()
        {
            List<DateTime> dates = new List<DateTime>();
            List<String> datesToStrings = new List<String>();
            dates.Add(DateTime.Now);
            dates.Add(DateTime.Now);
            dates.Add(DateTime.Now);
            foreach (DateTime date in dates)
            {
                datesToStrings.Add(date.ToString());
            }

            return datesToStrings;
        }
    }
}
