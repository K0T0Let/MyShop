using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using MyShop.data.Models;

namespace MyShop.data.Filter.FiltrationTypes
{
    public interface IFiltrationType
    {
        //Автозаполнение
        public bool Autocomplete { get; }

        //Логика фильтра
        public IEnumerable<Assembly> Filter(IEnumerable<Assembly> assemblies, int propertyId, List<ItemSpecifications> filterList);
    }
}
