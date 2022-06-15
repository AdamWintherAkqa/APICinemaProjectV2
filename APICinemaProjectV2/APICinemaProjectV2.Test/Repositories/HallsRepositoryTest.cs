using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APICinemaProjectV2.Test.Repositories
{
    public class HallsRepositoryTest
    {
        private readonly DbContextOptions<AbContext> _options;
        private readonly AbContext _context;
        private readonly HallRepository _hallRepository;

        public HallsRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<AbContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectHalls")
                .Options;

            _context = new(_options);

            _hallRepository = new HallRepository(_context);
        }

        [Fact]
        public async void SelectAllHalls_ShouldReturnListOfHalls_WhenHallsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Halls.Add(new() { HallID = 1, AmountOfSeats = 20, HallNumber = 10 });
            _context.Halls.Add(new() { HallID = 2, AmountOfSeats = 20, HallNumber = 11 });

            await _context.SaveChangesAsync();

            //act
            var result = await _hallRepository.GetAllHalls();

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Hall>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void SelectAllHalls_ShouldReturnEmptyListOfHalls_WhenNoHallExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _hallRepository.GetAllHalls();

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Hall>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void SelectHallById_ShouldReturnHall_WhenHallExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int hallId = 1;

            _context.Halls.Add(new()
            {
                HallID = 1,
                AmountOfSeats = 20,
                HallNumber = 10
            });

            await _context.SaveChangesAsync();

            //act
            var result = await _hallRepository.GetHallByID(hallId);

            //assert
            Assert.NotNull(result);
            Assert.IsType<Hall>(result);
            Assert.Equal(hallId, result.HallID);
        }

        [Fact]
        public async void SelectHallById_ShouldReturnNull_WhenHallDoesNotExist()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _hallRepository.GetHallByID(1);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewHall_shouldAddnewIdToHall_WhenSavingToDatabase()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int expectedNewId = 1;

            Hall hall = new()
            {
                HallID = 1,
                AmountOfSeats = 20,
                HallNumber = 10
            };

            //act
            var result = await _hallRepository.CreateHall(hall);

            //assert
            Assert.NotNull(result);
            Assert.IsType<Hall>(result);
            Assert.Equal(expectedNewId, result.HallID);
        }

        [Fact]
        public async void InsertNewHall_ShouldFailToAddNewHall_WhenHallIdAlreadyExists()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            Hall hall = new()
            {
                HallID = 1,
                AmountOfSeats = 20,
                HallNumber = 10
            };

            _context.Halls.Add(hall);
            await _context.SaveChangesAsync();

            //act
            async Task action() => await _hallRepository.CreateHall(hall);

            //assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);

            Assert.Contains("An item with the same key has already been added.", ex.Message);
        }

        //[Fact]
        //public async void UpdateExistingHall_ShouldChangeValuesOnHall_WhenHallExists()
        //{
        //    //arrange
        //    await _context.Database.EnsureDeletedAsync();

        //    int hallId = 1;

        //    Hall newHall = new()
        //    {
        //        HallId = hallId,
        //        Name = "George Georgesen",
        //        IsAlive = true,
        //        Password = "abcd"
        //    };

        //    _context.Hall.Add(newHall);
        //    await _context.SaveChangesAsync();

        //    Hall updateHall = new()
        //    {
        //        HallId = hallId,
        //        Name = "Updated Georgesen",
        //        IsAlive = true,
        //        Password = "abcd"
        //    };

        //    //act
        //    var result = await _hallRepository.
        //}

        [Fact]
        public async void DeleteHallById_ShouldReturnDeletedHall_WhenHallIsDeleted()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            int hallId = 1;

            Hall newHall = new()
            {
                HallID = 1,
                AmountOfSeats = 20,
                HallNumber = 10
            };

            _context.Halls.Add(newHall);
            await _context.SaveChangesAsync();

            //act
            var result = await _hallRepository.DeleteHallByID(hallId);
            var hall = await _hallRepository.GetHallByID(hallId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Hall>(result);
            Assert.Equal(hallId, result.HallID);
        }

        [Fact]
        public async void DeleteHallById_ShouldReturnNull_WhenHallDoesNotExist()
        {
            //arrange
            await _context.Database.EnsureDeletedAsync();

            //act
            var result = await _hallRepository.DeleteHallByID(1);

            //assert
            Assert.Null(result);
        }
    }
}
