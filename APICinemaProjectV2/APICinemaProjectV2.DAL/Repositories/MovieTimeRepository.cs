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
    public interface IMovieTimeRepository
    {
        Task<List<MovieTime>> GetAllMovieTimes();
        Task<MovieTime> GetMovieTimeByID(int id);
        Task<MovieTime> CreateMovieTime(MovieTime movietime);
        Task<MovieTime> DeleteMovieTimeByID(int id);
        Task<MovieTime> UpdateMovieTime(MovieTime movietime);
    }
    public class MovieTimeRepository : IMovieTimeRepository
    {
        private readonly AbContext context;
        public MovieTimeRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<MovieTime>> GetAllMovieTimes()
        {
            return await context.MovieTimes.ToListAsync();
        }
        public async Task<MovieTime> GetMovieTimeByID(int id)
        {
            return await context.MovieTimes.FirstOrDefaultAsync((movietimeObj) => movietimeObj.MovieTimeID == id);
        }
        public async Task<MovieTime> CreateMovieTime(MovieTime movietime)
        {
            context.MovieTimes.Add(movietime);
            await context.SaveChangesAsync();

            return movietime;
        }
        public async Task<MovieTime> DeleteMovieTimeByID(int id)
        {
            try
            {
                MovieTime item = context.MovieTimes.Where(item => item.MovieTimeID == id).Single();
                if (item != null)
                {
                    context.MovieTimes.Remove(item);
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
        public async Task<MovieTime> UpdateMovieTime(MovieTime movietime)
        {
            //context.Entry(movietime).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return movietime;
            //}
            //catch
            //{
            //    return null;
            //}

            MovieTime update = await context.MovieTimes.FirstOrDefaultAsync(item => item.MovieTimeID == movietime.MovieTimeID);
            if (update != null)
            {
                update.Time = movietime.Time;
                update.MovieID = movietime.MovieID;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
