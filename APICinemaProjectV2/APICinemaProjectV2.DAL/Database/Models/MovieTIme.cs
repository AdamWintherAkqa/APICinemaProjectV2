using System;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class MovieTime
    {
        [Key]
        public int MovieTimeID { get; set; } //PK
        public DateTime Time { get; set; } //The time when the movie runs.
        public int HallID { get; set; } //FK
        public Hall Hall { get; set; }
        public int MovieID { get; set; } //FK
        public Movie Movie { get; set; }
        
    }
}
