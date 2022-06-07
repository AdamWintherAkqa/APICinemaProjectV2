using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
    }
}
