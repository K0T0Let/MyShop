using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IImage
    {
        IEnumerable<Image> Images { get; }
    }
}
