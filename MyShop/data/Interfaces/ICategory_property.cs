using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface ICategory_property
    {
        IEnumerable<Category_property> Categories { get; }
    }
}
