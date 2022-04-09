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
                    /*RAMMemory = new List<CheckboxItem<uint>>
                    {
                        new CheckboxItem<uint>(false, 2),
                        new CheckboxItem<uint>(false, 4),
                        new CheckboxItem<uint>(false, 6),
                        new CheckboxItem<uint>(false, 8),
                        new CheckboxItem<uint>(false, 12),
                        new CheckboxItem<uint>(false, 16),
                    },*/
                    /*ROMMemory = new List<CheckboxItem<uint>>
                    {
                        new CheckboxItem<uint>(false, 8),
                        new CheckboxItem<uint>(false, 16),
                        new CheckboxItem<uint>(false, 32),
                        new CheckboxItem<uint>(false, 64),
                        new CheckboxItem<uint>(false, 128),
                        new CheckboxItem<uint>(false, 256),
                        new CheckboxItem<uint>(false, 512),
                        new CheckboxItem<uint>(false, 1024),
                    },*/
                    BatteryCapacityFrom = 0,
                    BatteryCapacityTo = 10000,
                    /*Core = new List<CheckboxItem<uint>>
                    {
                        new CheckboxItem<uint>(false, 2),
                        new CheckboxItem<uint>(false, 4),
                        new CheckboxItem<uint>(false, 6),
                        new CheckboxItem<uint>(false, 8),
                        new CheckboxItem<uint>(false, 12),
                        new CheckboxItem<uint>(false, 16),
                    },*/
                    /*SIMCard = new List<CheckboxItem<uint>>
                    {
                        new CheckboxItem<uint>(false, 1),
                        new CheckboxItem<uint>(false, 2),
                    }*/
                };
            } 
            set => throw new System.NotImplementedException(); }
    }
}
