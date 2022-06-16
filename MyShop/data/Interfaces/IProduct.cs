using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }
    }
}
