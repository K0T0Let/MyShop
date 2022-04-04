using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> categories { get; set; }
    }
}
