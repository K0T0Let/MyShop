namespace MyShop.data.Models
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public uint Availability { get; set; }
        public uint AvailabilityOrder { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
        public Category Category { get; set; }
        public uint CategoryID { get; set; }
    }
}
