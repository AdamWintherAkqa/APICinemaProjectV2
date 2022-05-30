using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.DAL.Repositories;
using APICinemaProject2.DAL.Models;

namespace APICinemaProjectV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandisesController : ControllerBase
    {
        private readonly IMerchandiseRepository context;

        public MerchandisesController(IMerchandiseRepository _context)
        {
            context = _context;
        }

        // GET: api/Merchandises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchandise>>> GetMerchandises()
        {
            try
            {
                List<Merchandise> result = await context.GetAllMerchandises(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Merchandises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchandise>> GetMerchandise(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var merchandise = context.GetMerchandiseByID(id);

                if (merchandise == null)
                {
                    return NotFound();
                }

                return await merchandise;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // PUT: api/Merchandises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchandise(int id, Merchandise merchandise)
        {
            try
            {
                if (id != merchandise.MerchandiseID)
                    return BadRequest("ID Mismatch");

                var merchandiseToUpdate = await context.GetMerchandiseByID(id);

                if (merchandiseToUpdate == null)
                {
                    return NotFound($"Merchandise with ID = {id} not found");
                }

                var result = await context.UpdateMerchandise(merchandise);

                if (result != null)
                {
                    return Ok(merchandise);
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

        // POST: api/Merchandises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merchandise>> PostMerchandise(Merchandise merchandise)
        {
            if (merchandise == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateMerchandise(merchandise);

                return merchandise;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Merchandises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchandise(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteMerchandiseByID(id);
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
