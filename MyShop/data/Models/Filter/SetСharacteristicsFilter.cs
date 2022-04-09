using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.Models.Filter
{
    public class SetСharacteristicsFilter
    {
        СharacteristicsFilter _сharacteristicsFilters;
        public СharacteristicsFilter сharacteristicsFilters { get => _сharacteristicsFilters; }
        IEnumerable<Product> _products;
        public IEnumerable<Product> products { get => _products; }
        IQueryCollection _query;
        public SetСharacteristicsFilter(СharacteristicsFilter сharacteristicsFilters, IEnumerable<Product> products, IQueryCollection query)
        {
            _сharacteristicsFilters = сharacteristicsFilters;
            _products = products;
            _query = query;
            beginFilter();
        }

        delegate bool Request(Product p);
        List<Product> temp;
        string key = "";
        void beginFilter()
        {
            _сharacteristicsFilters.ModelName = new List<CheckboxItem<string>>();
            _сharacteristicsFilters.Diagonal = new List<CheckboxItem<double>>();
            _сharacteristicsFilters.RAMMemory = new List<CheckboxItem<uint>>();
            _сharacteristicsFilters.ROMMemory = new List<CheckboxItem<uint>>();
            _сharacteristicsFilters.Core = new List<CheckboxItem<uint>>();
            _сharacteristicsFilters.SIMCard = new List<CheckboxItem<uint>>();
            foreach (var item in _products)
            {
                if (_сharacteristicsFilters.ModelName.FirstOrDefault(c => c.item == item.Characteristics.ModelName) == null)
                    _сharacteristicsFilters.ModelName.Add(new CheckboxItem<string>(false, item.Characteristics.ModelName));

                if (_сharacteristicsFilters.Diagonal.FirstOrDefault(c => c.item == item.Characteristics.Diagonal) == null)
                    _сharacteristicsFilters.Diagonal.Add(new CheckboxItem<double>(false, item.Characteristics.Diagonal));

                if (_сharacteristicsFilters.RAMMemory.FirstOrDefault(c => c.item == item.Characteristics.RAMMemory) == null)
                    _сharacteristicsFilters.RAMMemory.Add(new CheckboxItem<uint>(false, item.Characteristics.RAMMemory));

                if (_сharacteristicsFilters.ROMMemory.FirstOrDefault(c => c.item == item.Characteristics.ROMMemory) == null)
                    _сharacteristicsFilters.ROMMemory.Add(new CheckboxItem<uint>(false, item.Characteristics.ROMMemory));

                if (_сharacteristicsFilters.Core.FirstOrDefault(c => c.item == item.Characteristics.Core) == null)
                    _сharacteristicsFilters.Core.Add(new CheckboxItem<uint>(false, item.Characteristics.Core));

                if (_сharacteristicsFilters.SIMCard.FirstOrDefault(c => c.item == item.Characteristics.SIMCard) == null)
                    _сharacteristicsFilters.SIMCard.Add(new CheckboxItem<uint>(false, item.Characteristics.SIMCard));
            }

            if (_query != null)
            {
                string v;
                foreach (var q in _query)
                {
                    switch (q.Key.Split('-')[0])
                    {
                        case "Availability":
                            _сharacteristicsFilters.Availability = true;
                            _products = _products.Where(p => p.Characteristics.Availability > 0);
                            break;
                        case "Novelty":
                            _сharacteristicsFilters.Novelty = true;
                            _products = _products.Where(p => p.Characteristics.Novelty);
                            break;
                        case "PriceFrom":
                            v = q.Value;
                            if (v == "") v = _сharacteristicsFilters.PriceFrom.ToString();
                            _сharacteristicsFilters.PriceFrom = double.Parse(v);
                            _products = _products.Where(p => p.Characteristics.Price >= double.Parse(v)).ToList();
                            break;
                        case "PriceTo":
                            v = q.Value;
                            if (v == "") v = _сharacteristicsFilters.PriceTo.ToString();
                            _сharacteristicsFilters.PriceTo = double.Parse(v);
                            _products = _products.Where(p => p.Characteristics.Price <= double.Parse(v)).ToList();
                            break;
                        case "ModelName":
                            _сharacteristicsFilters.ModelName[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.ModelName == q.Value);
                            break;
                        case "RAMMemory":
                            _сharacteristicsFilters.RAMMemory[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.RAMMemory == uint.Parse(q.Value));
                            break;
                        case "ROMMemory":
                            _сharacteristicsFilters.ROMMemory[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.ROMMemory == uint.Parse(q.Value));
                            break;
                        case "BatteryCapacityFrom":
                            v = q.Value;
                            if (v == "") v = _сharacteristicsFilters.BatteryCapacityFrom.ToString();
                            _сharacteristicsFilters.BatteryCapacityFrom = uint.Parse(v);
                            _products = _products.Where(p => p.Characteristics.BatteryCapacity >= uint.Parse(v)).ToList();
                            break;
                        case "BatteryCapacityTo":
                            v = q.Value;
                            if (v == "") v = _сharacteristicsFilters.BatteryCapacityTo.ToString();
                            _сharacteristicsFilters.BatteryCapacityTo = uint.Parse(v);
                            _products = _products.Where(p => p.Characteristics.BatteryCapacity <= uint.Parse(v)).ToList();
                            break;
                        case "Diagonal":
                            _сharacteristicsFilters.Diagonal[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.Diagonal == double.Parse(q.Value));
                            break;
                        case "Core":
                            _сharacteristicsFilters.Core[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.Core == uint.Parse(q.Value));
                            break;
                        case "SIMCard":
                            _сharacteristicsFilters.SIMCard[int.Parse(q.Key.Split('-')[1])].checkbox = true;
                            setFilter(q.Key.Split('-')[0].ToString(), p => p.Characteristics.SIMCard == uint.Parse(q.Value));
                            break;
                    }
                }
                setFilter(true);
            }
        }

        void setFilter(bool end)
        {
            if (key == "")
                temp = new List<Product>(_products);
            if (end)
                _products = temp;
        }
        void setFilter(string qkey, Request request)
        {
            setFilter(false);
            if (key != qkey)
            {
                key = qkey;
                _products = temp;
                temp = new List<Product>(_products.Where(p => request(p)));
            }
            else
            {
                temp.AddRange(_products.Where(p => request(p)));
            }
        }
    }
}
