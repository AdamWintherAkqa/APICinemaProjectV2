using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICinemaProject2.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByID(int id);
        Task<Order> GetEntireOrderByID(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> DeleteOrderByID(int id);
        Task<Order> UpdateOrder(Order order);
        Task<List<Order>> GetOrdersWhereMovieTimeID(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly AbContext context;
        public OrderRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await context.Orders.ToListAsync();
        }
        public async Task<Order> GetOrderByID(int id)
        {
            return await context.Orders.FirstOrDefaultAsync((orderObj) => orderObj.OrderID == id);
        }
        public async Task<Order>GetEntireOrderByID(int id)
        {
            return await context.Orders
                .Include(order => order.Customer)
                .Include(order => order.MovieTime)
                .Include(order => order.Seats)
                .Include(order => order.CandyShops)
                .Include(order => order.Merchandise)
                .FirstOrDefaultAsync((orderObj) => orderObj.OrderID == id);
        }
        public async Task<List<Order>>GetOrdersWhereMovieTimeID(int id)
        {
            return await context.Orders.Where(order => order.MovieTimeID == id).Include(order => order.Seats).ToListAsync();
        }
        public async Task<Order> CreateOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return order;
        }
        public async Task<Order> DeleteOrderByID(int id)
        {
            try
            {
                Order item = context.Orders.Where(item => item.OrderID == id).Single();
                if (item != null)
                {
                    context.Orders.Remove(item);
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
        public async Task<Order> UpdateOrder(Order order)
        {
            //context.Entry(order).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return order;
            //}
            //catch
            //{
            //    return null;
            //}

            Order update = await context.Orders.FirstOrDefaultAsync(item => item.OrderID == order.OrderID);
            if (update != null)
            {
                update.Date = order.Date;
                update.MovieTimeID = order.MovieTimeID;
                update.CustomerID = order.CustomerID;
                update.AgeCheck = order.AgeCheck;
            
                //Måske have en price her? Så man kan ændre det? Eller gøres via controller

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
