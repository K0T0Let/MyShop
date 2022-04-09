using Microsoft.AspNetCore.Http;
using MyShop.data.interfaces;
using MyShop.data.mocks;
using MyShop.data.Models;
using MyShop.data.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.ModelViews
{
    public class ModelViewSection : IProducts, IСharacteristicsFilter
    {
        public ModelViewSection(uint BrandId, IEnumerable<Product> products, СharacteristicsFilter сharacteristicsFilters) : this(BrandId, null, products, сharacteristicsFilters)
        { }

        public ModelViewSection(uint BrandId, IQueryCollection query, IEnumerable<Product> products, СharacteristicsFilter сharacteristicsFilters)
        {
            this.BrandId = BrandId;
            this.query = query;
            this.products = products;
            this.сharacteristicsFilters = сharacteristicsFilters;           
        }

        public string BrandImg;
        public uint BrandId { get; set; }

        IQueryCollection query;

        IEnumerable<Product> _products;
        public IEnumerable<Product> products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value.Where(p => p.Characteristics.BrandId == BrandId);
                BrandImg = $"/img/{_products.First().Characteristics.Brand.GetType().Name}/{_products.First().Characteristics.Brand.Img}";
            }
        }

        //Создание фильтра
        СharacteristicsFilter _сharacteristicsFilters;
        public СharacteristicsFilter сharacteristicsFilters { 
            get 
            {
                return _сharacteristicsFilters;
            }
            set 
            {
                //Динамическое присвоение фильтров
                _сharacteristicsFilters = value;
                _сharacteristicsFilters.ModelName = new List<CheckboxList<string>>();
                _сharacteristicsFilters.Diagonal = new List<CheckboxList<double>>();
                foreach (var item in _products)
                {
                    if(_сharacteristicsFilters.ModelName.FirstOrDefault(c => c.item == item.Characteristics.ModelName) == null)
                        _сharacteristicsFilters.ModelName.Add(new CheckboxList<string>(false, item.Characteristics.ModelName));
                    if (_сharacteristicsFilters.Diagonal.FirstOrDefault(c => c.item == item.Characteristics.Diagonal) == null)
                        _сharacteristicsFilters.Diagonal.Add(new CheckboxList<double>(false, item.Characteristics.Diagonal));
                }

                if(query != null)
                {
                    int i;
                    string name;

                    foreach (var q in query)
                    {
                        switch (q.Key.Split('-')[0])
                        {
                            case "Availability":
                                _сharacteristicsFilters.Availability = true;
                                break;
                            case "Novelty":
                                _сharacteristicsFilters.Novelty = true;
                                _products = _products.Where(p => p.Characteristics.Novelty);
                                break;
                            case "PriceFrom":
                                _сharacteristicsFilters.PriceFrom = double.Parse(q.Value);
                                _products = _products.Where(p => p.Characteristics.Price >= double.Parse(q.Value));
                                break;
                            case "PriceTo":
                                _сharacteristicsFilters.PriceTo = double.Parse(q.Value);
                                _products = _products.Where(p => p.Characteristics.Price <= double.Parse(q.Value));
                                break;
                            case "ModelName":
                                _сharacteristicsFilters.ModelName[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                                i = int.Parse(q.Key.Split('-')[1]);
                                name = q.Key.Split('-')[0];

                                if(query[$"{name}-{i + 1}"].ToString() == "")
                                {
                                    List<Product> temp = new List<Product>();
                                    do
                                    {
                                        temp.AddRange(_products.Where(p => p.Characteristics.ModelName == query[$"{name}-{i}"]));
                                        i--;
                                    }
                                    while (query[$"{name}-{i}"].ToString() != "");
                                    _products = temp;
                                }                               
                                break;
                            case "RAMMemory":
                                _сharacteristicsFilters.RAMMemory[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                                i = int.Parse(q.Key.Split('-')[1]);
                                name = q.Key.Split('-')[0];

                                if (query[$"{name}-{i + 1}"].ToString() == "")
                                {
                                    List<Product> temp = new List<Product>();
                                    do
                                    {
                                        temp.AddRange(_products.Where(p => p.Characteristics.RAMMemory == uint.Parse(query[$"{name}-{i}"])));
                                        i--;
                                    }
                                    while (query[$"{name}-{i}"].ToString() != "");
                                    _products = temp;
                                }
                                break;
                            case "ROMMemory":
                                _сharacteristicsFilters.ROMMemory[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                                i = int.Parse(q.Key.Split('-')[1]);
                                name = q.Key.Split('-')[0];

                                if (query[$"{name}-{i + 1}"].ToString() == "")
                                {
                                    List<Product> temp = new List<Product>();
                                    do
                                    {
                                        temp.AddRange(_products.Where(p => p.Characteristics.ROMMemory == uint.Parse(query[$"{name}-{i}"])));
                                        i--;
                                    }
                                    while (query[$"{name}-{i}"].ToString() != "");
                                    _products = temp;
                                }
                                break;
                            case "BatteryCapacityFrom":
                                _сharacteristicsFilters.BatteryCapacityFrom = uint.Parse(q.Value);
                                _products = _products.Where(p => p.Characteristics.BatteryCapacity >= uint.Parse(q.Value));
                                break;
                            case "BatteryCapacityTo":
                                _сharacteristicsFilters.BatteryCapacityTo = uint.Parse(q.Value);
                                _products = _products.Where(p => p.Characteristics.BatteryCapacity <= uint.Parse(q.Value));
                                break;
                            case "Diagonal":
                                _сharacteristicsFilters.Diagonal[Convert.ToInt32(q.Key.Split('-')[1])].checkbox = true;
                                break;
                            case "Core":
                                _сharacteristicsFilters.Core[Convert.ToInt32(q.Key.Split('-')[1])].checkbox = true;
                                break;
                            case "SIMCard":
                                _сharacteristicsFilters.SIMCard[Convert.ToInt32(q.Key.Split('-')[1])].checkbox = true;
                                break;
                        }
                    }
                }
            } 
        }
    }
}
