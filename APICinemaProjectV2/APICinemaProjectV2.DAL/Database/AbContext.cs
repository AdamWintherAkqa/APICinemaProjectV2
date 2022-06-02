using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;

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
        //DESKTOP-R8OLBMM - Nicky 2

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0IT9HAR;Database=CinemaProject;Trusted_Connection=True;");
        }
        public DbSet<Actor> Actors { get; set; }
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
    }
}
