using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APICinemaProject2;

namespace APICinemaProject2.DAL.Models
{
    public class CandyShop
    {
        [Key]
        public int CandyShopID { get; set; } //PK
        public string CandyShopName { get; set; }
        public int CandyShopPrice { get; set; }
        public string CandyShopType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
