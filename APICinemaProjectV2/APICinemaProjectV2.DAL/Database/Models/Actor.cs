using APICinemaProject2.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
