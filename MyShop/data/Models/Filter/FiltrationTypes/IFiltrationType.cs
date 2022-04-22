using Microsoft.Extensions.Primitives;
using MyShop.data.Models.Product;
using System.Collections.Generic;

namespace MyShop.data.Models.Filter.FiltrationTypes
{
    public interface IFiltrationType
    {
        bool Autocomplete { get; }
        delegate bool Request(ProductModel p, string k, string[] o);
        event Request request;
        IEnumerable<ProductModel> Filter(IEnumerable<ProductModel> products, List<ItemSpecifications> сharacteristicsPoints, IEnumerable<KeyValuePair<string, StringValues>> filterList);
    }
}
