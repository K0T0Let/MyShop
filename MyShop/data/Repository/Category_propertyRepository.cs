using MyShop.data.Interfaces;
using MyShop.data.Models;
using MyShop.data.DB;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyShop.data.Repository
{
    public class Category_propertyRepository : ICategory_property
    {
        public readonly ShopDBContext shopDBContext;

        public Category_propertyRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }
        public IEnumerable<Category_property> Categories => shopDBContext.Category_property.Include(c => c.Properties);
    }
}
