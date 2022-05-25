using APICinemaProject2.DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; } // PK
        public string MovieName { get; set; }
        public int MoviePlayTime { get; set; }
        public int MovieAgeLimit { get; set; }
        public int HallID { get; set; }
        public Hall Hall { get; set; }
        //public int InstructorID { get; set; } // FK
        //public Instructor Instructor { get; set; }

        //public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
