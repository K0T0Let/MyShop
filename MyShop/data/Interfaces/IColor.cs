using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IColor
    {
        IEnumerable<Color> Colors { get; }
    }
}
