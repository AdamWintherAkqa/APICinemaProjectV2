using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
    }
}
