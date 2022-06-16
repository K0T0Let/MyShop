using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product> Products { get; set; } = new();
        public int ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
