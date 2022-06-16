using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Filter.FiltrationTypes
{
    public class LonelyCheckbox : FiltrationEvent, IFiltrationType
    {
        public LonelyCheckbox(Request request) : base(request)
        {
        }

        public bool Autocomplete => false;

        public IEnumerable<Assembly> Filter(IEnumerable<Assembly> assemblies, int propertyId, List<ItemSpecifications> filterList)
        {
            return assemblies.Where(a => ActionRequest(a, propertyId, filterList));
        }
    }
}
