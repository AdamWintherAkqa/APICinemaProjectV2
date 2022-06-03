using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; } //PK
        public DateTime Date { get; set; }
        public bool AgeCheck { get; set; }
        public int? MovieTimeID { get; set; } //FK
        public MovieTime MovieTime { get; set; }
        public int? CustomerID { get; set; } //FK
        public Customer Customer { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<CandyShop> CandyShops { get; set; }
        public virtual ICollection<Merchandise> Merchandise { get; set; }
    }
}
