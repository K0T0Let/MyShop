using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Repository
{
    public class PropertyRepository : IProperty
    {
        public readonly ShopDBContext shopDBContext;

        public PropertyRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }

        public IEnumerable<Property> Properties => shopDBContext.Properties
            .Include(p => p.Connections)
            .Include(p => p.Category_property);
    }
}
