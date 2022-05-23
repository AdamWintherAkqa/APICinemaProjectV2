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
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieByID(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> DeleteMovieByID(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
    public class MovieRepository : IMovieRepository
    {
        private readonly AbContext context;
        public MovieRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieByID(int id)
        {
            return await context.Movies.FirstOrDefaultAsync((movieObj) => movieObj.MovieID == id);
        }
        public async Task<Movie> CreateMovie(Movie movie)
        {
            context.Movies.Add(movie);
            await context.SaveChangesAsync();

            return movie;
        }
        public async Task<Movie> DeleteMovieByID(int id)
        {
            try
            {
                Movie item = context.Movies.Where(item => item.MovieID == id).Single();
                if (item != null)
                {
                    context.Movies.Remove(item);
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
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            //context.Entry(movie).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return movie;
            //}
            //catch
            //{
            //    return null;
            //}

            Movie update = await context.Movies.FirstOrDefaultAsync(item => item.MovieID == movie.MovieID);
            if (update != null)
            {
                update.MovieName = movie.MovieName;
                update.MoviePlayTime = movie.MoviePlayTime;
                update.MovieAgeLimit = movie.MovieAgeLimit;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
