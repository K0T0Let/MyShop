using MyShop.data.Interfaces;
using MyShop.data.Models.Filter;
using MyShop.data.Models.Filter.FiltrationTypes;
using MyShop.data.Utilit.MethodsExtension;
using System.Collections.Generic;

namespace MyShop.data.Mocks
{
    public class MockСharacteristicsFilter : IСharacteristicsFilter
    {
        public Dictionary<string, Characteristic> characteristics => new Dictionary<string, Characteristic>()
        {
            ["Availability"] = new Characteristic
            {
                Header = "",
                filtrationType = new LonelyCheckbox((p, k, f) => p.Characteristics[k].ToDouble() > 0),
                CharacteristicsPoints = new List<ItemSpecifications>
                        {
                            new ItemSpecifications {Name = "В наличии", Meaning = "false"}
                        }
            },

            ["Novelty"] = new Characteristic
            {
                Header = "",
                filtrationType = new LonelyCheckbox((p, k, f) => p.Characteristics[k] == f[0]),
                CharacteristicsPoints = new List<ItemSpecifications>
                        {
                            new ItemSpecifications {Name = "Только новинки", Meaning = "false"}
                        }
            },

            ["Price"] = new Characteristic
            {
                Header = "Стоимость",
                filtrationType = new RangeSelection((p, k, f) => p.Characteristics[k].ToDouble() >= f[0].ToDouble()
                                                              && p.Characteristics[k].ToDouble() <= f[1].ToDouble()),
                CharacteristicsPoints = new List<ItemSpecifications>
                        {
                            new ItemSpecifications { Name = "To", Meaning = "0" },
                            new ItemSpecifications { Name = "From", Meaning = "1000000" },
                        }
            },

            ["ModelName"] = new Characteristic
            {
                Header = "Модель",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },

            ["RAMMemory"] = new Characteristic
            {
                Header = "Объем оперативной памяти",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },

            ["ROMMemory"] = new Characteristic
            {
                Header = "Объем встроенной памяти",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },

            ["BatteryCapacity"] = new Characteristic
            {
                Header = "Объем аккумулятора",
                filtrationType = new RangeSelection((p, k, f) => p.Characteristics[k].ToDouble() >= f[0].ToDouble()
                                                              && p.Characteristics[k].ToDouble() <= f[1].ToDouble()),
                CharacteristicsPoints = new List<ItemSpecifications>
                        {
                            new ItemSpecifications { Name = "To", Meaning = "0" },
                            new ItemSpecifications { Name = "From", Meaning = "10000" },
                        }
            },

            ["Diagonal"] = new Characteristic
            {
                Header = "Диоганаль экрана",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },

            ["Core"] = new Characteristic
            {
                Header = "Количество ядер",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },

            ["SIMCard"] = new Characteristic
            {
                Header = "Количество SIM-карт",
                filtrationType = new CheckboxList((p, k, f) => p.Characteristics[k] == f[0]),
            },
        };
    }
}
