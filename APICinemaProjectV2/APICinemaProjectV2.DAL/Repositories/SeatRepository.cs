using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICinemaProject2.DAL.Repositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAllSeats();
        Task<Seat> GetSeatByID(int id);
        Task<Seat> CreateSeat(Seat seat);
        Task<Seat> DeleteSeatByID(int id);
        Task<Seat> UpdateSeat(Seat seat);
        Task<List<Seat>> GetEntireSeats();
        Task<List<Seat>> GetSeatsWhereHallID(int id);
    }
    public class SeatRepository : ISeatRepository
    {
        private readonly AbContext context;
        public SeatRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Seat>> GetAllSeats()
        {
            return await context.Seats.ToListAsync();
        }
        public async Task<Seat> GetSeatByID(int id)
        {
            return await context.Seats.FirstOrDefaultAsync((seatObj) => seatObj.SeatID == id);
        }
        public async Task<List<Seat>> GetEntireSeats()
        {
            return await context.Seats
                .Include(seat => seat.Orders).Include(seat => seat.Hall).ToListAsync();
        }
        public async Task<List<Seat>> GetSeatsWhereHallID(int id)
        {
            return await context.Seats
                .Where(seat => seat.HallID == id).ToListAsync();
        }
        public async Task<Seat> CreateSeat(Seat seat)
        {
            context.Seats.Add(seat);
            await context.SaveChangesAsync();

            return seat;
        }
        public async Task<Seat> DeleteSeatByID(int id)
        {
            try
            {
                Seat item = context.Seats.Where(item => item.SeatID == id).Single();
                if (item != null)
                {
                    context.Seats.Remove(item);
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
        public async Task<Seat> UpdateSeat(Seat seat)
        {
            //context.Entry(seat).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return seat;
            //}
            //catch
            //{
            //    return null;
            //}

            Seat update = await context.Seats.FirstOrDefaultAsync(item => item.SeatID == seat.SeatID);
            if (update != null)
            {
                update.SeatNumber = seat.SeatNumber;
                update.SeatRowLetter = seat.SeatRowLetter;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
