using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APICinemaProject2.DAL.Repositories
{
    public interface IHallRepository
    {
        Task<List<Hall>> GetAllHalls();
        Task<Hall> GetHallByID(int id);
        Task<Hall> CreateHall(Hall hall);
        Task<Hall> DeleteHallByID(int id);
        Task<Hall> UpdateHall(Hall hall);
    }
    public class HallRepository : IHallRepository
    {
        private readonly AbContext context;
        public HallRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            return await context.Halls.ToListAsync();
        }
        public async Task<Hall> GetHallByID(int id)
        {
            return await context.Halls.FirstOrDefaultAsync((hallObj) => hallObj.HallID == id);
        }
        public async Task<Hall> CreateHall(Hall hall)
        {
            context.Halls.Add(hall);
            await context.SaveChangesAsync();

            return hall;
        }
        public async Task<Hall> DeleteHallByID(int id)
        {
            try
            {
                Hall item = context.Halls.Where(item => item.HallID == id).Single();
                if (item != null)
                {
                    context.Halls.Remove(item);
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
        public async Task<Hall> UpdateHall(Hall hall)
        {
            //context.Entry(hall).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return hall;
            //}
            //catch
            //{
            //    return null;
            //}

            Hall update = await context.Halls.FirstOrDefaultAsync(item => item.HallID == hall.HallID);
            if (update != null)
            {
                update.HallNumber= hall.HallNumber;
                update.AmountOfSeats = hall.AmountOfSeats;
                update.MovieID = hall.MovieID;
                

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
