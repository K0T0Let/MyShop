using MyShop.data.Models.Filter;
using System.Collections.Generic;

namespace MyShop.data.Models
{
    public class СharacteristicsFilter
    {
        public bool Availability { get; set; }
        public bool Novelty { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public List<CheckboxItem<string>> ModelName { get; set; }
        public List<CheckboxItem<uint>> RAMMemory { get; set; }
        public List<CheckboxItem<uint>> ROMMemory { get; set; }
        public uint BatteryCapacityFrom { get; set; }
        public uint BatteryCapacityTo { get; set; }
        public List<CheckboxItem<double>> Diagonal { get; set; }
        public List<CheckboxItem<uint>> Core { get; set; }
        public List<CheckboxItem<uint>> SIMCard { get; set; }
    }

    public class GetСharacteristicsFilter
    {
        public СharacteristicsFilter filter;
        public GetСharacteristicsFilter(СharacteristicsFilter filter) => this.filter = filter;
    }
}
