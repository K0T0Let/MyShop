using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Repository
{
    public class ImageRepository : IImage
    {
        public readonly ShopDBContext shopDBContext;

        public ImageRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }

        public IEnumerable<Image> Images => shopDBContext.Images;
    }
}
