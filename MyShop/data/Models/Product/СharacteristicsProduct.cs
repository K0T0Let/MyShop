namespace MyShop.data.Models
{
    public class СharacteristicsProduct
    {
        public uint Availability { get; set; }
        public bool Novelty { get; set; }
        public double Price { get; set; }
        public string ModelName { get; set; }
        public uint BrandId { get; set; }
        public Brand Brand { get; set; }
        public uint RAMMemory { get; set; }
        public uint ROMMemory { get; set; }
        public uint BatteryCapacity { get; set; }
        public double Diagonal { get; set; }
        public uint Core { get; set; }
        public uint SIMCard { get; set; }
        public ProductColor Color { get; set; }
    }
}
