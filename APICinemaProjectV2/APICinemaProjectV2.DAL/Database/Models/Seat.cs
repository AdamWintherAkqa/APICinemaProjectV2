using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Models
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; } // PK
        public int HallID { get; set; } // FK
        public Hall Hall { get; set; }
        public int SeatNumber { get; set; }
        public string SeatRowLetter { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
