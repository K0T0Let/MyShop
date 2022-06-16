using System.Collections.Generic;
using MyShop.data.Filter.FiltrationTypes;

namespace MyShop.data.Filter
{
    public class FilterElement
    {
        public string Header { get; set; }
        public IFiltrationType filtrationType { get; set; }
        public List<ItemSpecifications> items { get; set; }
    }
}
