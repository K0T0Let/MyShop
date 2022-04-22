using MyShop.data.Models.Product;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface IProducts
    {
        IEnumerable<ProductModel> products { get; set; }
    }
}
