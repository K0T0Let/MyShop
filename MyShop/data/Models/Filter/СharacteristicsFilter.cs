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
        public List<CheckboxList<string>> ModelName { get; set; }
        public List<CheckboxList<uint>> RAMMemory { get; set; }
        public List<CheckboxList<uint>> ROMMemory { get; set; }
        public uint BatteryCapacityFrom { get; set; }
        public uint BatteryCapacityTo { get; set; }
        public List<CheckboxList<double>> Diagonal { get; set; }
        public List<CheckboxList<uint>> Core { get; set; }
        public List<CheckboxList<uint>> SIMCard { get; set; }
    }

    public class GetСharacteristicsFilter
    {
        public СharacteristicsFilter filter;
        public GetСharacteristicsFilter(СharacteristicsFilter filter) => this.filter = filter;
    }
}
