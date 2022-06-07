using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICinemaProject2.DAL.Database.Models
{
    public class Merchandise
    {
        [Key]
        public int MerchandiseID { get; set; }
        public string MerchandiseType { get; set; }
        public string MerchandiseName { get; set; }
        public string MerchandiseColor { get; set; }
        public int MerchandisePrice { get; set; }
        public string MerchandiseSize { get; set; }
        public int MerchandiseStock { get; set; }
        public string MerchandiseDescription { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}
