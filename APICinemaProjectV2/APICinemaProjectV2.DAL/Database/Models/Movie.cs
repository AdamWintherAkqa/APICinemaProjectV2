using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; } // PK
        public string MovieName { get; set; }
        public int MoviePlayTime { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public int MovieAgeLimit { get; set; }
        public bool MovieIsChosen { get; set; }
        public string MovieImageURL { get; set; }
        //public string MovieDescription { get; set; }
        public int? InstructorID { get; set; } // FK
        public Instructor Instructor { get; set; }
        public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
