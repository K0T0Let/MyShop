using MyShop.data.Filter.FiltrationTypes;
using System.Collections.Generic;
using MyShop.data.Interfaces;
using MyShop.data.Utilit.MethodsExtension;

namespace MyShop.data.Filter
{
    public class СharacteristicsFilter : IСharacteristicsFilter
    {
        public Dictionary<int, FilterElement> filters => new Dictionary<int, FilterElement>
        {
            [1] = new FilterElement
            {
                Header = "",
                filtrationType = new LonelyCheckbox((a, k, f) => a.Connections[k].Meaning == f[0].Value),
                items = new List<ItemSpecifications>
                {
                    new ItemSpecifications {Meaning = "Только новинки", Value = "false"}
                }
            },

            [4] = new FilterElement
            {
                Header = "",
                filtrationType = new LonelyCheckbox((a, k, f) => a.Connections[k].Meaning.ToDouble() > 0),
                items = new List<ItemSpecifications>
                {
                    new ItemSpecifications {Meaning = "Только в наличии", Value = "false"}
                }
            },

            [3] = new FilterElement
            {
                Header = "Объем встроенной памяти",
                filtrationType = new CheckboxList((a, k, f) => a.Connections[k].Meaning == f[0].Meaning),
            },

            [2] = new FilterElement
            {
                Header = "Цена",
                filtrationType = new RangeSelection((a, k, f) => a.Connections[k].Meaning.ToDouble() >= f[0].Value.ToDouble()
                                                              && a.Connections[k].Meaning.ToDouble() <= f[1].Value.ToDouble()),
                items = new List<ItemSpecifications>
                {
                    new ItemSpecifications {Meaning = "To", Value = "0"},
                    new ItemSpecifications {Meaning = "From", Value = "1000000"}
                }
            },
        };
    }
}
