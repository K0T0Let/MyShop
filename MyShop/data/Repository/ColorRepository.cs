using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Repository
{
    public class ColorRepository : IColor
    {
        public readonly ShopDBContext shopDBContext;

        public ColorRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }

        public IEnumerable<Color> Colors => shopDBContext.Colors;
    }
}
