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
    public class CandyShopsController : ControllerBase
    {
        private readonly ICandyShopRepository context;

        public CandyShopsController(ICandyShopRepository _context)
        {
            context = _context;
        }

        // GET: api/CandyShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandyShop>>> GetCandyShops()
        {
            try
            {
                List<CandyShop> result = await context.GetAllCandyShops(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/CandyShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandyShop>> GetCandyShop(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var candyShop = context.GetCandyShopByID(id);

                if (candyShop == null)
                {
                    return NotFound();
                }

                return await candyShop;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCandyShopAndOrderByID/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetCandyShopAndOrderByID(int id)
        {
            try
            {
                var result = await context.GetCandyShopAndOrderByID(id);

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

        // PUT: api/CandyShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandyShop(int id, CandyShop candyShop)
        {
            try
            {
                if (id != candyShop.CandyShopID)
                    return BadRequest("ID Mismatch");

                var candyShopToUpdate = await context.GetCandyShopByID(id);

                if (candyShopToUpdate == null)
                {
                    return NotFound($"CandyShop with ID = {id} not found");
                }

                var result = await context.UpdateCandyShop(candyShop);

                if (result != null)
                {
                    return Ok(candyShop);
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

        // POST: api/CandyShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandyShop>> PostCandyShop(CandyShop candyShop)
        {
            if (candyShop == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateCandyShop(candyShop);

                return candyShop;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/CandyShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandyShop(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteCandyShopByID(id);
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
