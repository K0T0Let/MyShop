using MyShop.data.Models.Filter.FiltrationTypes;
using System.Collections.Generic;

namespace MyShop.data.Models.Filter
{
    public class Characteristic
    {
        public string Header { get; set; }
        public List<ItemSpecifications> CharacteristicsPoints { get; set; }
        public IFiltrationType filtrationType { get; set; }
    }
}
