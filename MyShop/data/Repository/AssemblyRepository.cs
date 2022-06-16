using Microsoft.EntityFrameworkCore;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Repository
{
    public class AssemblyRepository : IAssembly
    {
        public readonly ShopDBContext shopDBContext;

        public AssemblyRepository(ShopDBContext shopDBContext)
        {
            this.shopDBContext = shopDBContext;
        }

        public IEnumerable<Assembly> Assemblies => shopDBContext.Assemblys
            .Include(a => a.Color)
            .Include(a => a.Product)
            .Include(a => a.Product.Assemblies)
            .Include(a => a.Product.Brand)
            .Include(a => a.Product.Brand.Image)
            .Include(a => a.Connections).ThenInclude(c => c.Property).ThenInclude(p => p.Category_property)
            .Include(a => a.Images)
            .Include(a => a.Properties);
    }
}
