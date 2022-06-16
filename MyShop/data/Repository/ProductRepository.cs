using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Repository
{
    public class ProductRepository : IProduct
    {
        public readonly ShopDBContext shopDBContext;

        public ProductRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }

        public IEnumerable<Product> Products => shopDBContext.Products.Include(p => p.Brand);
    }
}
