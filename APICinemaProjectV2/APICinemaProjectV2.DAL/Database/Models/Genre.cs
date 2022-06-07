using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
