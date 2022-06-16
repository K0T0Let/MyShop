namespace MyShop.data.Models
{
    public class Connection_table
    {
        public int AssemblyId { get; set; }
        public Assembly? Assembly { get; set; }
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
        public string? Meaning { get; set; }
    }
}
