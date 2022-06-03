using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Hall
    {
        [Key]
        public int HallID { get; set; } //Pk
        public int HallNumber { get; set; }
        public int AmountOfSeats { get; set; }
        public int? MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
