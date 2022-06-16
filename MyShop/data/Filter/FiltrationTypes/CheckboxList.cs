using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Filter.FiltrationTypes
{
    public class CheckboxList : FiltrationEvent, IFiltrationType
    {
        public CheckboxList(Request request) : base(request)
        {
        }

        public bool Autocomplete => true;

        public IEnumerable<Assembly> Filter(IEnumerable<Assembly> assemblies, int propertyId, List<ItemSpecifications> filterList)
        {
            List<Assembly> temp = new List<Assembly>();
            foreach (var item in filterList)
            {
                temp.AddRange(assemblies.Where(a => ActionRequest(a, propertyId, new List<ItemSpecifications>{ item })));
            }
            assemblies = temp;
            return assemblies;
        }
    }
}
