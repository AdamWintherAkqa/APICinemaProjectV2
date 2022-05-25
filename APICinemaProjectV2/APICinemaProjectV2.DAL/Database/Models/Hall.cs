using APICinemaProject2.DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Hall
    {
        [Key]
        public int HallID { get; set; } //Pk
        public int HallNumber { get; set; }
        public int MovieID { get; set; } //FK
        public Movie Movie { get; set; }
        public int AmountOfSeats { get; set; }
    }
}
