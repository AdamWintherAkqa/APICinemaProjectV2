using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; } //PK
        public string ActorName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
