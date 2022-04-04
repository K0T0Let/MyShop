using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Utilit
{
    public class AllModels : ICategory, IProducts
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
