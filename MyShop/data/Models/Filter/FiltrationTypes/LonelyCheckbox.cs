using Microsoft.Extensions.Primitives;
using MyShop.data.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Models.Filter.FiltrationTypes
{
    public class LonelyCheckbox : IFiltrationType
    {
        public bool Autocomplete { get => false; }
        public LonelyCheckbox(IFiltrationType.Request request) => this.request = request;

        public event IFiltrationType.Request request;

        public IEnumerable<ProductModel> Filter(IEnumerable<ProductModel> products, List<ItemSpecifications> сharacteristicsPoints, IEnumerable<KeyValuePair<string, StringValues>> filterList)
        {
            return products.Where(p => request(p, filterList.First().Key.Split('-')[0], new string[] {"true"}));
        }
    }
}
