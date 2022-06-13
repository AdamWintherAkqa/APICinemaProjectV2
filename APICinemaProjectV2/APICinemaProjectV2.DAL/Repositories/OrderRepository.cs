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
        Task<Order> PostAndPutOrder(Order order);
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

        //public async Task<Order> PostAndPutORder(Order order)
        //{
        //    Order orderToPost;

        //    orderToPost.AgeCheck = order.AgeCheck;
        //    orderToPost.Date = order.Date;
        //    context.Orders.Add(orderToPost);

        //}

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

            //Order update = await context.Orders.FirstOrDefaultAsync(item => item.OrderID == order.OrderID);
            //if (update != null)
            //{
            //    update.Date = order.Date;
            //    update.MovieTimeID = order.MovieTimeID;
            //    update.CustomerID = order.CustomerID;
            //    update.AgeCheck = order.AgeCheck;
            //    update.Seats = order.Seats;
            //    update.Merchandise = order.Merchandise;
            //    update.CandyShops = order.CandyShops;


            //    //Måske have en price her? Så man kan ændre det? Eller gøres via controller

            //    await context.SaveChangesAsync();
            //}
            //return update;

            await context.SaveChangesAsync();
            return order;

        }

        public async Task<Order> PostAndPutOrder(Order order)
        {
            Order orderToPost = new()
            {
                AgeCheck = order.AgeCheck,
                Date = order.Date
            };

            List<Seat> seats = new List<Seat>();

            foreach (var seat in order.Seats)
            {
                Seat seatToPost = new Seat()
                {
                    HallID = seat.HallID,
                    SeatNumber = seat.SeatNumber,
                    SeatRowLetter = seat.SeatRowLetter
                };
                seats.Add(seatToPost);
            }

            //Seat seat = new Seat()
            //{
            //    HallID = order.Seats
            //    SeatNumber = 10,
            //    SeatRowLetter = "A",
            //};

            
            var postedOrder = context.Orders.Add(orderToPost);
            await context.SaveChangesAsync();

            Order orderToUpdate = context.Orders
                .Include(order => order.Customer)
                .Include(order => order.MovieTime)
                .Include(order => order.Seats)
                .Include(order => order.CandyShops)
                .Include(order => order.Merchandise)
                .FirstOrDefault((orderObj) => orderObj.OrderID == orderToPost.OrderID);

            if (orderToUpdate != null)
            {
                orderToUpdate.Seats = seats;
                //orderToUpdate.Merchandise = order.Merchandise;
                //orderToUpdate.CustomerID = order.CustomerID;
                //orderToUpdate.CandyShops = order.CandyShops;

                var result = await context.SaveChangesAsync();

                if (result != 0)
                {
                    return orderToUpdate;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
