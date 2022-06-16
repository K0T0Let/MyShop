using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Category_propertyId { get; set; }
        public Category_property Category_property { get; set; }
        public List<Assembly> Assemblies { get; set; } = new();
        public List<Connection_table> Connections { get; set; } = new();
    }
}
