using Microsoft.AspNetCore.Http;
using MyShop.data.interfaces;
using MyShop.data.mocks;
using MyShop.data.Models;
using MyShop.data.Models.Filter;
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

        СharacteristicsFilter _сharacteristicsFilters;
        public СharacteristicsFilter сharacteristicsFilters { 
            get 
            {
                return _сharacteristicsFilters;
            }
            set 
            {
                var filter = new SetСharacteristicsFilter(value, _products, query);
                _сharacteristicsFilters = filter.сharacteristicsFilters;
                _products = filter.products;
            } 
        }
    }
}
