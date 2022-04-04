using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Order
    {
        public uint Id { get; set; }
        public string BuyerName  { get; set; }
        public uint PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public List<Product> products { get; set; }
    }
}
