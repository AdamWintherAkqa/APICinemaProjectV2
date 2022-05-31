using APICinemaProject2.DAL.Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; } // PK
        public int? HallID { get; set; } // FK
        public Hall Hall { get; set; }
        public int SeatNumber { get; set; }
        public string SeatRowLetter { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
