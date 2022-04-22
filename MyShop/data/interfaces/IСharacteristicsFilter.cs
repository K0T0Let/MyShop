using MyShop.data.Models.Filter;
using System.Collections.Generic;

namespace MyShop.data.interfaces
{
    public interface IСharacteristicsFilter
    {
        Dictionary<string, Characteristic> characteristics { get; set; }
    }
}
