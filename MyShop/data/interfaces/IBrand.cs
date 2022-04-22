using MyShop.data.Models.Brand;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface IBrand
    {
        IEnumerable<BrandModel> brands { get; set; }
    }
}
