using Microsoft.AspNetCore.Http;
using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;
using MyShop.data.Filter;

namespace MyShop.data.ModelViews
{
    public class MVSection
    {
        public MVSection(List<Assembly> assemblies, IQueryCollection query, IСharacteristicsFilter сharacteristicsFilter)
        {
            this.query = query;
            assembly = assemblies;
            filters = сharacteristicsFilter.filters;
        }

        //Выход
        public Brand Brand { get; set; }

        IQueryCollection query { get; set; }

        IEnumerable<Assembly> _assembly;

        //Выход
        public IEnumerable<Assembly> assembly
        {
            get => _assembly;
            set
            {
                _assembly = value;
                Brand = value.FirstOrDefault().Product.Brand;
            }
        }

        Dictionary<int, FilterElement> _filters;

        //Выход
        public Dictionary<int, FilterElement> filters
        {
            get => _filters;
            set
            {
                var filtering = new Filtering(assembly, value, query);
                _filters = filtering.filters;
                _assembly = filtering.assemblies;
            }
        }
    }
}
