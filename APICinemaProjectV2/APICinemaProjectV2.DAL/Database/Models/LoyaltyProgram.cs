using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database.Models
{
    public class LoyaltyProgram
    {
        [Key]
        public int LoyaltyProgramID { get; set; } // PK
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}
