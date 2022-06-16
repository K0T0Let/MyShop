using Microsoft.AspNetCore.Http;
using MyShop.data.Models;
using MyShop.data.Utilit.MethodsExtension;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Filter
{
    public class Filtering
    {
        public Filtering(IEnumerable<Assembly> assemblies, Dictionary<int, FilterElement> filters, IQueryCollection query)
        {
            this.assemblies = assemblies;
            this.filters = filters;
            this.query = query;

            autocomplete();
            setMeaningInQuery();
            beginFilter();
        }

        public IEnumerable<Assembly> assemblies { get; set; }
        public Dictionary<int, FilterElement> filters { get; set; }
        IQueryCollection query { get; set; }

        void autocomplete()
        {
            foreach (var item in assemblies)
            {
                foreach (var c in item.Connections)
                {
                    if (filters.ContainsKey(c.PropertyId) && filters[c.PropertyId].filtrationType.Autocomplete)
                    {
                        if (filters[c.PropertyId].items == null)
                            filters[c.PropertyId].items = new List<ItemSpecifications>();
                        if (filters[c.PropertyId].items.FirstOrDefault(i => i.Meaning == c.Meaning) == null)
                            filters[c.PropertyId].items.Add(new ItemSpecifications {Meaning = c.Meaning, Value = "false" });
                    }
                }
            }
        }

        void setMeaningInQuery()
        {
            foreach (var item in filters)
            {
                item.Value.items = item.Value.items.OrderBy(i => i.Meaning.ToDouble()).ToList();
                for (int i = 0; i < item.Value.items.Count; i++)
                {
                    if (query.ContainsKey($"{item.Key}-{i}"))
                        item.Value.items[i].Value = query[$"{item.Key}-{i}"];
                }
            }
        }

        void beginFilter()
        {
            List<string> alreadyFiltered = new List<string>();
            foreach (var item in query)
            {
                string[] mas = item.Key.Split('-');
                if (!alreadyFiltered.Contains(mas[0]))
                {
                    alreadyFiltered.Add(mas[0]);
                    assemblies = filters[int.Parse(mas[0])].filtrationType.Filter(
                        assemblies,
                        int.Parse(mas[0])-1,
                        filters[int.Parse(mas[0])].items.Where(i => i.Value != "false").ToList()
                        );
                }
            }
        }
    }
}
