using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class CandyShop
    {
        [Key]
        public int CandyShopID { get; set; } //PK
        public string CandyShopName { get; set; }
        public string CandyShopImageURL { get; set; }
        public int CandyShopPrice { get; set; }
        public string CandyShopType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
