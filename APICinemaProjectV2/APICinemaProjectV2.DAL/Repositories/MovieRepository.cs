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
        Task<Movie> PostAndPutMovie(Movie movie);
    }
    public class MovieRepository : IMovieRepository 
    {
        private readonly AbContext context; //Får alle DB Set.
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
        public async Task<Movie> PostAndPutMovie(Movie movie)
        {
            Movie movieToPost = new() //Laver et objekt af Movie uden FKs.
            {
                MovieAgeLimit = movie.MovieAgeLimit,
                MovieImageURL = movie.MovieImageURL,
                MovieIsChosen = movie.MovieIsChosen,
                MovieName = movie.MovieName,
                MoviePlayTime = movie.MoviePlayTime,
                MovieReleaseDate = movie.MovieReleaseDate
            };

            List<Actor> actors = new List<Actor>(); //Laver en liste af actors og genres som er de to mange-til-mange relations i denne.
            List<Genre> genres = new List<Genre>();

            foreach (var actor in movie.Actors) //For hvor actor/genre der er på movie objektet,
                                                //laver den en ny actor eller genre hvor den får værdierne ind.
                                                //Og det tilføjes til den tomme liste over.
                    
            {
                Actor actorToPost = new Actor()
                {
                    ActorID = actor.ActorID,
                    ActorName = actor.ActorName
                };
                actors.Add(actorToPost);
            }

            foreach (var genre in movie.Genre)
            {
                Genre genreToPost = new Genre()
                {
                    GenreID = genre.GenreID,
                    GenreName = genre.GenreName
                };
                genres.Add(genreToPost);
            }

            var postedMovie = context.Movies.Add(movieToPost); //Så postes movien, og gemmes.
            await context.SaveChangesAsync();

            Movie movieToUpdate = context.Movies //Så laves et nyt objekt som hedder movieToUpdate (Som er en GetByID),
                                                 //som tager den den movie som lige er postet, og lægger dens info i det nye objekt.
                .Include(movie => movie.Genre)
                .Include(movie => movie.Actors)
                .FirstOrDefault((movieObj) => movieObj.MovieID == movieToPost.MovieID);

            if (movieToUpdate != null) //Hvis vi kan finde den på ID'et, så køres nedenstående:
            {
                movieToUpdate.Actors = movie.Actors;
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.InstructorID = movie.InstructorID; 

                var result = await context.SaveChangesAsync();

                if (result != 0)
                {
                    return movieToUpdate; //Genre og actors, og instructorID puttes over i movieToUpdate og gemmes.
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
