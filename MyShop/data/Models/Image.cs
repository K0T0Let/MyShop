using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Src { get; set; }
        public List<Brand> Brands { get; set; } = new();
        public List<Assembly> Assemblys { get; set; } = new();
    }
}
