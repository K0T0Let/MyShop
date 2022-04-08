using MyShop.data.interfaces;
using MyShop.data.Models;
using MyShop.data.Models.Filter;
using System.Collections.Generic;

namespace MyShop.data.mocks
{
    public class MockСharacteristicsFilter : IСharacteristicsFilter
    {
        public СharacteristicsFilter сharacteristicsFilters { 
            get 
            {
                return new СharacteristicsFilter
                {
                    Availability = true,
                    Novelty = false,
                    PriceFrom = 0,
                    PriceTo = 1000000,
                    RAMMemory = new List<CheckboxList<uint>>
                    {
                        new CheckboxList<uint>(false, 2),
                        new CheckboxList<uint>(false, 4),
                        new CheckboxList<uint>(false, 6),
                        new CheckboxList<uint>(false, 8),
                        new CheckboxList<uint>(false, 12),
                        new CheckboxList<uint>(false, 16),
                    },
                    ROMMemory = new List<CheckboxList<uint>>
                    {
                        new CheckboxList<uint>(false, 8),
                        new CheckboxList<uint>(false, 16),
                        new CheckboxList<uint>(false, 32),
                        new CheckboxList<uint>(false, 64),
                        new CheckboxList<uint>(false, 128),
                        new CheckboxList<uint>(false, 256),
                        new CheckboxList<uint>(false, 512),
                        new CheckboxList<uint>(false, 1024),
                    },
                    BatteryCapacityFrom = 0,
                    BatteryCapacityTo = 10000,
                    Core = new List<CheckboxList<uint>>
                    {
                        new CheckboxList<uint>(false, 2),
                        new CheckboxList<uint>(false, 4),
                        new CheckboxList<uint>(false, 6),
                        new CheckboxList<uint>(false, 8),
                        new CheckboxList<uint>(false, 12),
                        new CheckboxList<uint>(false, 16),
                    },
                    SIMCard = new List<CheckboxList<uint>>
                    {
                        new CheckboxList<uint>(false, 1),
                        new CheckboxList<uint>(false, 2),
                    }
                };
            } 
            set => throw new System.NotImplementedException(); }
    }
}
