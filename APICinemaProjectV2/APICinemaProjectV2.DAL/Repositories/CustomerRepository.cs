using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APICinemaProjectV2.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByID(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> DeleteCustomerByID(int id);
        Task<Customer> UpdateCustomer(Customer customer);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AbContext context;
        public CustomerRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerByID(int id)
        {
            return await context.Customers.FirstOrDefaultAsync((customerObj) => customerObj.CustomerID == id);
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return customer;
        }
        public async Task<Customer> DeleteCustomerByID(int id)
        {
            try
            {
                Customer item = context.Customers.Where(item => item.CustomerID == id).Single();
                if (item != null)
                {
                    context.Customers.Remove(item);
                    await context.SaveChangesAsync();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            }
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            //context.Entry(customer).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return customer;
            //}
            //catch
            //{
            //    return null;
            //}

            Customer update = await context.Customers.FirstOrDefaultAsync(item => item.CustomerID == customer.CustomerID);
            if (update != null)
            {
                update.CustomerName = customer.CustomerName;
                update.CustomerID = customer.CustomerID;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
