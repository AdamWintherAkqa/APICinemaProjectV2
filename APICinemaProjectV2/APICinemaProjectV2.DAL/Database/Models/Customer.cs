using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public bool CustomerIsVIP { get; set; }
        public string CustomerEmail { get; set; }
        public bool CustomerGender { get; set; }
        public string CustomerPassword { get; set; }

    }
}
