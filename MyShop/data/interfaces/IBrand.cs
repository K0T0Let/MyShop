using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IBrand
    {
        IEnumerable<Brand> Brands { get; }
    }
}
