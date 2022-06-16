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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository context;

        public CustomersController(ICustomerRepository _context)
        {
            context = _context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                List<Customer> result = await context.GetAllCustomers(); // Ok kan typecast 99% af alt kode whoo!
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

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var customer = context.GetCustomerByID(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return await customer;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerByEmail/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            try
            {
                var customer = context.GetCustomerByEmail(email);

                if (customer == null)
                {
                    return NotFound();
                }

                return await customer;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerByEmailAndPassword/{email}/{password}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmailAndPassword(string email, string password)
        {
            if (email == null || password == null)
            {
                return BadRequest();
            }

            try
            {
                var customer = context.GetCustomerByEmailAndPassword(email, password);

                if (customer == null)
                {
                    return NotFound();
                }

                return await customer;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerID)
                    return BadRequest("ID Mismatch");

                var customerToUpdate = await context.GetCustomerByID(id);

                if (customerToUpdate == null)
                {
                    return NotFound($"Customer with ID = {id} not found");
                }

                var result = await context.UpdateCustomer(customer);

                if (result != null)
                {
                    return Ok(customer);
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            try
            {
                List<Customer> customers = await context.GetAllCustomers();

                foreach (var cust in customers)
                {
                    if (customer.CustomerEmail == cust.CustomerEmail)
                    {
                        return BadRequest("Duplicate Email");
                    }
                }


                await context.CreateCustomer(customer);

                return customer;
            }
            catch (Exception ex)
            {
                return (ActionResult)BadRequest(ex.Message);
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await context.DeleteCustomerByID(id);
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
