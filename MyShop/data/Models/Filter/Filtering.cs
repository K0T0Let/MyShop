using Microsoft.AspNetCore.Http;
using MyShop.data.interfaces;
using MyShop.data.Models.Product;
using MyShop.data.Utilit.MethodsExtension;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Models.Filter
{
    public class Filtering : IProducts, IСharacteristicsFilter
    {
        public Filtering(IEnumerable<ProductModel> products, Dictionary<string, Characteristic> characteristics, IQueryCollection query)
        {
            this.products = products;
            this.characteristics = characteristics;
            this.query = query;

            autocomplete();
            setMeaningInQuery();
            beginFilter();
        }

        public IEnumerable<ProductModel> products { get; set; }
        public Dictionary<string, Characteristic> characteristics { get; set; }
        IQueryCollection query { get; set; }

        void autocomplete()
        {
            foreach (var item in products)
            {
                foreach (var c in item.Characteristics)
                {
                    if (characteristics.ContainsKey(c.Key) && characteristics[c.Key].filtrationType.Autocomplete)
                    {
                        if (characteristics[c.Key].CharacteristicsPoints == null)
                            characteristics[c.Key].CharacteristicsPoints = new List<ItemSpecifications>();
                        if (characteristics[c.Key].CharacteristicsPoints.FirstOrDefault(i => i.Name == c.Value) == null)
                            characteristics[c.Key].CharacteristicsPoints.Add(new ItemSpecifications { Name = c.Value, Meaning = "false" });
                    }
                }
            }
        }

        void setMeaningInQuery()
        {
            foreach (var item in characteristics)
            {
                item.Value.CharacteristicsPoints = item.Value.CharacteristicsPoints.OrderBy(c => c.Name.ToDouble()).ToList();
                for (int i = 0; i < item.Value.CharacteristicsPoints.Count; i++)
                {
                    if (query.ContainsKey($"{item.Key}-{i}"))
                        item.Value.CharacteristicsPoints[i].Meaning = query[$"{item.Key}-{i}"];
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
                    products = characteristics[mas[0]].filtrationType.Filter(
                        products,
                        characteristics[mas[0]].CharacteristicsPoints,
                        query.Where(q => q.Key.Contains(mas[0]))
                        );
                }
            }
        }
    }
}
