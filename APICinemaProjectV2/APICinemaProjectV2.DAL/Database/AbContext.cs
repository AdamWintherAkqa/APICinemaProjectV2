using APICinemaProject2.DAL.Database.Models;
using APICinemaProject2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database
{
    public class AbContext : DbContext
    {
        public AbContext() { }
        public AbContext(DbContextOptions<AbContext> options) : base(options) { }

        //skal udkommenteres hvis repository tests skal virke
        //CPH00151\MSSQLSERVER01 - Adam 1
        //DESKTOP-0IT9HAR - Adam 2
        //EGC29749\H2SQLSOMMER -- Nicky 1

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EGC29749\H2SQLSOMMER;Database=CinemaProject;Trusted_Connection=True;");
        }


        public DbSet<CandyShop> CandyShops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieTime> MovieTimes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Actor> Actors { get; set; }
    }
}
