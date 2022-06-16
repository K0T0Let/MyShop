using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Category_property
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Property> Properties { get; set; } = new();
    }
}
