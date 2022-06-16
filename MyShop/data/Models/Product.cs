using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<Assembly> Assemblies { get; set; }
    }
}
