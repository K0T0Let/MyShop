using System.Collections.Generic;

namespace MyShop.data.Models.Filter
{
    public class FilterCheckboxList<T>
    {
        public FilterCheckboxList(string Name, string ListName, List<CheckboxList<T>> checkboxLists, string Prefix)
        {
            this.Name = Name;
            this.ListName = ListName;
            this.checkboxLists = checkboxLists;
            this.Prefix = Prefix;
        }
        public string Name { get; set; }
        public string ListName { get; set; }
        public string Prefix { get; set; }
        public List<CheckboxList<T>> checkboxLists { get; set; }
    }
}
