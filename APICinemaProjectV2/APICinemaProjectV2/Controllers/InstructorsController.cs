using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.DAL.Repositories;

namespace APICinemaProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorRepository context;

        public InstructorsController(IInstructorRepository _context)
        {
            context = _context;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors()
        {
            try
            {
                List<Instructor> result = await context.GetAllInstructors(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var instructor = context.GetInstructorByID(id);

                if (instructor == null)
                {
                    return NotFound();
                }

                return await instructor;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, Instructor instructor)
        {
            try
            {
                if (id != instructor.InstructorID)
                    return BadRequest("ID Mismatch");

                var instructorToUpdate = await context.GetInstructorByID(id);

                if (instructorToUpdate == null)
                {
                    return NotFound($"Instructor with ID = {id} not found");
                }

                var result = await context.UpdateInstructor(instructor);

                if (result != null)
                {
                    return Ok(instructor);
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

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateInstructor(instructor);

                return instructor;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteInstructorByID(id);
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
