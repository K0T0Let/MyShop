using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Assembly
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public List<Property> Properties { get; set; } = new();
        public List<Connection_table> Connections { get; set; } = new();
        public List<Image> Images { get; set; } = new();
    }
}
