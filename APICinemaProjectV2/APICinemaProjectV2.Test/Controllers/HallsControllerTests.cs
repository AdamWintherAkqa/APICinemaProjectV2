using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Repositories;
using APICinemaProjectV2.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace APICinemaProjectV2.Test.Controllers
{
    public class HallControllerTests
    {
        //SUT - system under test
        private readonly HallController _sut;
        //Mock er til for at simulere data
        private readonly Mock<IHallRepository> _hallRepo = new Mock<IHallRepository>();

        public HallControllerTests()
        {
            _sut = new HallController(_hallRepo.Object);
        }

        //decorates a method in xunit
        [Fact]
        public async void GetHallsTest_ShouldReturn200()
        {
            //arrange
            List<Hall> halls = new List<Hall>
            {
                new Hall { HallID = 1, AmountOfSeats = 20, HallNumber = 10},
                new Hall { HallID = 2, AmountOfSeats = 20, HallNumber = 11},
                new Hall { HallID = 3, AmountOfSeats = 20, HallNumber = 12 },
            };

            _hallRepo.Setup(hallObj => hallObj.GetAllHalls()).ReturnsAsync(halls);

            //act
            var result = await _sut.GetHalls();    //Simulerer at vi invoker en metode med masser af data
            var status = (IStatusCodeActionResult)result;

            //assert
            Assert.Equal(200, status.StatusCode);
        }

        [Fact]
        public async void GetAll_Halls_ListNotExisting()
        {
            //arrange
            _hallRepo.Setup(objOfRepository => objOfRepository.GetAllHalls()).ReturnsAsync(() => null);

            //act
            var result = await _sut.GetHalls();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //Unit test on the controller for 204
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoAUthorExists()
        {
            //arrange
            List<Hall> halls = new();
            _hallRepo.Setup(x => x.GetAllHalls()).ReturnsAsync(halls);

            //act
            var result = await _sut.GetHalls();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //arrange
            _hallRepo.Setup(x => x.GetAllHalls()).ReturnsAsync(() => null);
            //act
            var result = await _sut.GetHalls();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //arrange
            _hallRepo.Setup(x => x.GetAllHalls()).ReturnsAsync(() => throw new Exception("This is an exception"));
            //act
            var result = await _sut.GetHalls();

            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
