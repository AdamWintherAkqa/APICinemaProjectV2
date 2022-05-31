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
    public class LoyaltyProgramsController : ControllerBase
    {
        private readonly ILoyaltyProgramRepository context;

        public LoyaltyProgramsController(ILoyaltyProgramRepository _context)
        {
            context = _context;
        }

        // GET: api/LoyaltyPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyProgram>>> GetLoyaltyPrograms()
        {
            try
            {
                List<LoyaltyProgram> result = await context.GetAllLoyaltyPrograms(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/LoyaltyPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoyaltyProgram>> GetLoyaltyProgram(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var loyaltyprogram = context.GetLoyaltyProgramByID(id);

                if (loyaltyprogram == null)
                {
                    return NotFound();
                }

                return await loyaltyprogram;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // PUT: api/LoyaltyPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoyaltyProgram(int id, LoyaltyProgram loyaltyprogram)
        {
            try
            {
                if (id != loyaltyprogram.LoyaltyProgramID)
                    return BadRequest("ID Mismatch");

                var loyaltyprogramToUpdate = await context.GetLoyaltyProgramByID(id);

                if (loyaltyprogramToUpdate == null)
                {
                    return NotFound($"LoyaltyProgram with ID = {id} not found");
                }

                var result = await context.UpdateLoyaltyProgram(loyaltyprogram);

                if (result != null)
                {
                    return Ok(loyaltyprogram);
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

        // POST: api/LoyaltyPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoyaltyProgram>> PostLoyaltyProgram(LoyaltyProgram loyaltyprogram)
        {
            if (loyaltyprogram == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateLoyaltyProgram(loyaltyprogram);

                return loyaltyprogram;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/LoyaltyPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyProgram(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteLoyaltyProgramByID(id);
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
