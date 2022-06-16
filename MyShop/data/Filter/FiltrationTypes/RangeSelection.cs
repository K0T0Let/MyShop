using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Filter.FiltrationTypes
{
    public class RangeSelection : FiltrationEvent, IFiltrationType
    {
        public RangeSelection(Request request) : base(request)
        {
        }

        public bool Autocomplete => false;

        public IEnumerable<Assembly> Filter(IEnumerable<Assembly> assemblies, int propertyId, List<ItemSpecifications> filterList)
        {
            foreach (var item in filterList)
                if (item.Value == "")
                    item.Value = "0";

            string[] mas = new string[2]
            {
                filterList[0].Value,
                filterList[1].Value
            };

            assemblies = assemblies.Where(a => ActionRequest(a, propertyId, filterList));
            return assemblies;
        }
    }
}
