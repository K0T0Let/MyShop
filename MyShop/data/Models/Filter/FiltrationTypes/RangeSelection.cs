using Microsoft.Extensions.Primitives;
using MyShop.data.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Models.Filter.FiltrationTypes
{
    public class RangeSelection : IFiltrationType
    {
        public bool Autocomplete { get => false; }
        public RangeSelection(IFiltrationType.Request request) => this.request = request;

        public event IFiltrationType.Request request;

        public IEnumerable<ProductModel> Filter(IEnumerable<ProductModel> products, List<ItemSpecifications> сharacteristicsPoints, IEnumerable<KeyValuePair<string, StringValues>> filterList)
        {
            foreach (var item in сharacteristicsPoints)
                if (item.Meaning == "")
                    item.Meaning = "0";

            string[] mas = new string[2]
            {
                filterList.FirstOrDefault(i => i.Key.Contains("0")).Value,
                filterList.FirstOrDefault(i => i.Key.Contains("1")).Value
            };

            for (int i = 0; i < mas.Length; i++)
                if (mas[i] == "")
                    mas[i] = "0";

            products = products.Where(p => request(p, filterList.First().Key.Split('-')[0], mas));
            return products;
        }
    }
}
