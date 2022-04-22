using MyShop.data.Models.Brand;
using System.Collections.Generic;

namespace MyShop.data.Models.Product
{
    public class ProductModel
    {
        public uint Id { get; set; }
        public ProductImg Img { get; set; }
        public ProductColor Color { get; set; }
        public uint BrandId { get; set; }
        public BrandModel Brand { get; set; }
        public Dictionary<string, string> Characteristics { get; set; }
    }
}
