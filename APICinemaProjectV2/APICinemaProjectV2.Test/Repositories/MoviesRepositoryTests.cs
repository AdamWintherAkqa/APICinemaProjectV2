using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APICinemaProjectV2.Test.Repositories
{
    public class MoviesRepositoryTests
    {
        private readonly DbContextOptions<AbContext> _options;
        private readonly AbContext _context;
        private readonly MovieRepository _movieRepository;

        public MoviesRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AbContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectMovies")
                .Options;

            _context = new(_options);

            _movieRepository = new MovieRepository(_context);
        }

        [Fact]
        public async void SelectAllMovies_ShouldReturnListOfMovies_WhenMoviesExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Movies.Add(new() { MovieID = 1, MovieName = "Movie 1", MovieImageURL = "abcd", MovieAgeLimit = 1, MovieIsChosen = true, MoviePlayTime = 120, MovieReleaseDate = DateTime.Now });
            _context.Movies.Add(new() { MovieID = 2, MovieName = "Movie 2", MovieImageURL = "abcd", MovieAgeLimit = 1, MovieIsChosen = true, MoviePlayTime = 120, MovieReleaseDate = DateTime.Now });

            await _context.SaveChangesAsync();

            //act
            var result = await _movieRepository.GetAllMovies();

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Movie>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void SelectAllMovies_ShouldReturnEmptyListOfMovies_WhenNoMovieExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _movieRepository.GetAllMovies();

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Movie>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void SelectMovieById_ShouldReturnMovie_WhenMovieExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int movieId = 1;

            _context.Movies.Add(new()
            {
                MovieID = 1,
                MovieName = "Movie 1",
                MovieImageURL = "abcd",
                MovieAgeLimit = 1,
                MovieIsChosen = true,
                MoviePlayTime = 120,
                MovieReleaseDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            //act
            var result = await _movieRepository.GetMovieByID(movieId);

            //assert
            Assert.NotNull(result);
            Assert.IsType<Movie>(result);
            Assert.Equal(movieId, result.MovieID);
        }

        [Fact]
        public async void SelectMovieById_ShouldReturnNull_WhenMovieDoesNotExist()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _movieRepository.GetMovieByID(1);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewMovie_shouldAddnewIdToMovie_WhenSavingToDatabase()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int expectedNewId = 1;

            Movie movie = new()
            {
                MovieID = 1,
                MovieName = "Movie 1",
                MovieImageURL = "abcd",
                MovieAgeLimit = 1,
                MovieIsChosen = true,
                MoviePlayTime = 120,
                MovieReleaseDate = DateTime.Now
            };

            //act
            var result = await _movieRepository.CreateMovie(movie);

            //assert
            Assert.NotNull(result);
            Assert.IsType<Movie>(result);
            Assert.Equal(expectedNewId, result.MovieID);
        }

        [Fact]
        public async void InsertNewMovie_ShouldFailToAddNewMovie_WhenMovieIdAlreadyExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            Movie movie = new()
            {
                MovieID = 1,
                MovieName = "Movie 1",
                MovieImageURL = "abcd",
                MovieAgeLimit = 1,
                MovieIsChosen = true,
                MoviePlayTime = 120,
                MovieReleaseDate = DateTime.Now
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            //act
            async Task action() => await _movieRepository.CreateMovie(movie);

            //assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);

            Assert.Contains("An item with the same key has already been added.", ex.Message);
        }

        //[Fact]
        //public async void UpdateExistingMovie_ShouldChangeValuesOnMovie_WhenMovieExists()
        //{
        //    //arrange
        //    await _context.Database.EnsureDeletedAsync();

        //    int movieId = 1;

        //    Movie newMovie = new()
        //    {
        //        MovieId = movieId,
        //        Name = "George Georgesen",
        //        IsAlive = true,
        //        Password = "abcd"
        //    };

        //    _context.Movie.Add(newMovie);
        //    await _context.SaveChangesAsync();

        //    Movie updateMovie = new()
        //    {
        //        MovieId = movieId,
        //        Name = "Updated Georgesen",
        //        IsAlive = true,
        //        Password = "abcd"
        //    };

        //    //act
        //    var result = await _movieRepository.
        //}

        [Fact]
        public async void DeleteMovieById_ShouldReturnDeletedMovie_WhenMovieIsDeleted()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int movieId = 1;

            Movie newMovie = new()
            {
                MovieID = movieId,
                MovieName = "Movie 1",
                MovieImageURL = "abcd",
                MovieAgeLimit = 1,
                MovieIsChosen = true,
                MoviePlayTime = 120,
                MovieReleaseDate = DateTime.Now
            };

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            //act
            var result = await _movieRepository.DeleteMovieByID(movieId);
            var movie = await _movieRepository.GetMovieByID(movieId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Movie>(result);
            Assert.Equal(movieId, result.MovieID);
        }

        [Fact]
        public async void DeleteMovieById_ShouldReturnNull_WhenMovieDoesNotExist()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _movieRepository.DeleteMovieByID(1);

            //assert
            Assert.Null(result);
        }
    }
}
