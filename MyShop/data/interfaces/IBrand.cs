using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface IBrand
    {
        IEnumerable<Brand> brands { get; set; }
    }
}
