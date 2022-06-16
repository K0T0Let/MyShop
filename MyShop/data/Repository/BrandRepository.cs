using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Repository
{
    public class BrandRepository : IBrand
    {
        public readonly ShopDBContext shopDBContext;
        public BrandRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }
        public IEnumerable<Brand> Brands => shopDBContext.Brands.Include(b => b.Image);
    }
}
