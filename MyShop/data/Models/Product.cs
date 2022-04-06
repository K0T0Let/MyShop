namespace MyShop.data.Models
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public bool Novelty { get; set; }
        public uint Availability { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
        public Brand brand { get; set; }
        public uint BrandId { get; set; }
    }
}
