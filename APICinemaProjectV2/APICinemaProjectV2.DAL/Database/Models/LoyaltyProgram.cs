using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class LoyaltyProgram
    {
        [Key]
        public int LoyaltyProgramID { get; set; } // PK
        public int? LoyaltyPoints { get; set; }
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}
