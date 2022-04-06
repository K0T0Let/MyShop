using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> products { get; set; }
    }
}
