using Microsoft.Extensions.Primitives;
using MyShop.data.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Models.Filter.FiltrationTypes
{
    public class CheckboxList : IFiltrationType
    {
        public bool Autocomplete { get => true; }
        public CheckboxList(IFiltrationType.Request request) => this.request = request;

        public event IFiltrationType.Request request;

        public IEnumerable<ProductModel> Filter(IEnumerable<ProductModel> products, List<ItemSpecifications> сharacteristicsPoints, IEnumerable<KeyValuePair<string, StringValues>> filterList)
        {
            List<ProductModel> temp = new List<ProductModel>();
            foreach (var item in filterList)
            {
                temp.AddRange(products.Where(p => request(p, item.Key.Split('-')[0], new string[] { сharacteristicsPoints[int.Parse(item.Key.Split('-')[1])].Name })));
            }
            products = temp;
            return products;
        }
    }
}
