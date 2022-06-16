using MyShop.data.Filter;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IСharacteristicsFilter
    {
        Dictionary<int, FilterElement> filters { get; }
    }
}
