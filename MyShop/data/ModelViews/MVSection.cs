using Microsoft.AspNetCore.Http;
using MyShop.data.interfaces;
using MyShop.data.Models.Brand;
using MyShop.data.Models.Filter;
using MyShop.data.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.ModelViews
{
    public class MVSection : IProducts, IBrand, IСharacteristicsFilter
    {
        public MVSection(uint BrandId, IEnumerable<BrandModel> brands, IQueryCollection query, IEnumerable<ProductModel> products, Dictionary<string, Characteristic> characteristics)
        {
            this.BrandId = BrandId;
            this.query = query;
            this.brands = brands;
            this.products = products;
            this.characteristics = characteristics;
        }

        public uint BrandId { get; set; }
        public string BrandImg { get; set; }
        IQueryCollection query { get; set; }

        IEnumerable<ProductModel> _products;
        public IEnumerable<ProductModel> products 
        { 
            get => _products; 
            set
            {
                _products = value.Where(p => p.BrandId == BrandId);
                BrandImg = $"/img/Brand/{brands.FirstOrDefault(b => b.Id == BrandId).Img}";
            }
        }

        Dictionary<string, Characteristic> _characteristics;
        public Dictionary<string, Characteristic> characteristics 
        { 
            get => _characteristics; 
            set
            {
                var filtering = new Filtering(products, value, query);
                _characteristics = filtering.characteristics;
                _products = filtering.products;
            }
        }

        IEnumerable<BrandModel> _brands;
        public IEnumerable<BrandModel> brands 
        { 
            get => _brands; 
            set => _brands = value; 
        }
    }
}
