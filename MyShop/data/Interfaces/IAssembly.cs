using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Interfaces
{
    public interface IAssembly
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}
