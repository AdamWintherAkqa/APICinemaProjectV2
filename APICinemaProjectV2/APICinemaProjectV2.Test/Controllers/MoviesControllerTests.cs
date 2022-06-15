using APICinemaProject2.DAL.Database.Models;
using APICinemaProjectV2.Controllers;
using APICinemaProjectV2.DAL.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace APICinemaProjectV2.Test.Controllers
{
    /// <summary>
    /// Jeg vil gerne kunne teste API laget.
    /// DVS. vi kommer ikke til at benytte database mm.
    /// DVS. vi kan ikke teste det vi gerne vil.
    /// 
    /// AAA
    /// ARRANGE - DEFINITION ( VARIABLER MM)
    /// ACT     - RESULT ( INVOKE VORES METODER )
    /// ASSERT  - SAMMENLIGNE 2 VÆRDIER
    ///         - Returnere jeg det rigtige osv.
    /// </summary>
    public class MoviesControllerTests
    {
        //SUT - system under test
        private readonly MoviesController _sut;
        //Mock er til for at simulere data
        private readonly Mock<IMovieRepository> _movieRepo = new Mock<IMovieRepository>();

        public MoviesControllerTests()
        {
            _sut = new MoviesController(_movieRepo.Object);
        }

        //decorates a method in xunit
        [Fact]
        public async void GetMoviesTest_ShouldReturn200()
        {
            //arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie { MovieID = 1, MovieName = "Movie 1", MovieImageURL  = "abcd", MovieAgeLimit = 1, MovieIsChosen = true, MoviePlayTime = 120, MovieReleaseDate = DateTime.Now },
                new Movie { MovieID = 2, MovieName = "Movie 2", MovieImageURL  = "abcd", MovieAgeLimit = 1, MovieIsChosen = true, MoviePlayTime = 120, MovieReleaseDate = DateTime.Now },
                new Movie { MovieID = 3, MovieName = "Movie 3", MovieImageURL  = "abcd", MovieAgeLimit = 1, MovieIsChosen = true, MoviePlayTime = 120, MovieReleaseDate = DateTime.Now },
            };

            _movieRepo.Setup(movieObj => movieObj.GetAllMovies()).ReturnsAsync(movies);

            //act
            var result = await _sut.GetMovies();    //Simulerer at vi invoker en metode med masser af data
            var status = (IStatusCodeActionResult)result;

            //assert
            Assert.Equal(200, status.StatusCode);
        }

        [Fact]
        public async void GetAll_Movies_ListNotExisting()
        {
            //arrange
            _movieRepo.Setup(objOfRepository => objOfRepository.GetAllMovies()).ReturnsAsync(() => null);

            //act
            var result = await _sut.GetMovies();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Unit test on the controller for 204
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAUthorExists()
        {
            //arrange
            List<Movie> movies = new();
            _movieRepo.Setup(x => x.GetAllMovies()).ReturnsAsync(movies);

            //act
            var result = await _sut.GetMovies();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //arrange
            _movieRepo.Setup(x => x.GetAllMovies()).ReturnsAsync(() => null);
            //act
            var result = await _sut.GetMovies();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //arrange
            _movieRepo.Setup(x => x.GetAllMovies()).ReturnsAsync(() => throw new Exception("This is an exception"));
            //act
            var result = await _sut.GetMovies();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
