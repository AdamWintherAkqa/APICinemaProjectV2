using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICinemaProjectV2.DAL.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieByID(int id);
        Task<List<Movie>> GetAllMoviesAndActors();
        //Task<List<Movie>> GetAllMoviesAndHalls();
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> DeleteMovieByID(int id);
        Task<Movie> UpdateMovie(Movie movie);
        Task<List<Movie>> GetMoviesFrontPage();
        Task<Movie> GetEntireMovie(int id);
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

        public async Task<List<Movie>> GetAllMoviesAndActors()
        {
            List<Movie> movies = new List<Movie>();
            movies = await context.Movies.Include(movie => movie.Actors).ToListAsync();
            return movies;
        }
        //public async Task<List<Movie>> GetAllMoviesAndHalls()
        //{
        //    List<Movie> movies = new List<Movie>();
        //    movies = await context.Movies.Include(movies => movies.Hall).ToListAsync();
        //    return movies;
        //}

        public async Task<List<Movie>> GetMoviesFrontPage()
        {
            List<Movie> movies = new List<Movie>();
            movies = await context.Movies.Include(movies => movies.Genre).ToListAsync();
            
            return movies;
        }
        public async Task<Movie> GetEntireMovie(int id)
        {
            //context.Movies.FirstOrDefaultAsync((movieObj) => movieObj.MovieID == id);
            var movies = await context.Movies.Include(movie => movie.Actors).Include(movie => movie.Genre).Include(movie => movie.Instructor).FirstOrDefaultAsync((movieObj) => movieObj.MovieID == id);

            return movies;
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
            Movie update = await context.Movies.FirstOrDefaultAsync(item => item.MovieID == movie.MovieID);
            if (update != null)
            {
                update.MovieName = movie.MovieName;
                update.MoviePlayTime = movie.MoviePlayTime;
                update.MovieAgeLimit = movie.MovieAgeLimit;
                update.Actors = movie.Actors;
                update.InstructorID = movie.InstructorID;
                update.MovieImageURL = movie.MovieImageURL;
                update.MovieIsChosen = movie.MovieIsChosen;
                

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
