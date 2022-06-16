using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IProperty
    {
        IEnumerable<Property> Properties { get; }
    }
}
