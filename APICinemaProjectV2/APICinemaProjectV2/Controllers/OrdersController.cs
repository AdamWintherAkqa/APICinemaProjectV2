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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository context;

        public OrdersController(IOrderRepository _context)
        {
            context = _context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                List<Order> result = await context.GetAllOrders(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var order = context.GetOrderByID(id);

                if (order == null)
                {
                    return NotFound();
                }

                return await order;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEntireOrderByID/{id}")]
        public async Task<ActionResult<Order>> GetEntireOrderByID(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var order = context.GetEntireOrderByID(id);

                if (order == null)
                {
                    return NotFound();
                }

                return await order;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrdersWhereMovieTimeID/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWhereMovieTimeID(int id)
        {
            try
            {
                List<Order> result = await context.GetOrdersWhereMovieTimeID(id);

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

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            try
            {
                if (id != order.OrderID)
                    return BadRequest("ID Mismatch");

                var orderToUpdate = await context.GetOrderByID(id);

                if (orderToUpdate == null)
                {
                    return NotFound($"Order with ID = {id} not found");
                }

                var result = await context.UpdateOrder(order);

                if (result != null)
                {
                    return Ok(order);
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            try
            {
                await context.CreateOrder(order);

                return order;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpPost("PostAndPutOrder")]
        public async Task<ActionResult<Order>> PostAndPutOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            try
            {
                await context.PostAndPutOrder(order);
                
                //Order orderToPost = new()
                //{
                //    AgeCheck = order.AgeCheck,
                //    Date = order.Date
                //};


                //var postedOrder = await context.CreateOrder(orderToPost);

                //var orderToUpdate = await context.GetOrderByID(postedOrder.OrderID);

                //if (orderToUpdate != null)
                //{
                //    orderToUpdate.Seats = order.Seats;
                //    orderToUpdate.Merchandise = order.Merchandise;
                //    orderToUpdate.CustomerID = order.CustomerID;
                //    orderToUpdate.CandyShops = order.CandyShops;

                //    var result = await context.UpdateOrder(orderToUpdate);

                //    if (result != null)
                //    {
                //        return Ok(order);
                //    }
                //    else
                //    {
                //        return BadRequest("Null i Repo");
                //    }
                //}


                return order;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        try
        {
            var response = await context.DeleteOrderByID(id);
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
