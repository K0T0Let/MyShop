using MyShop.data.interfaces;
using MyShop.data.Models.Brand;
using MyShop.data.Models.Product;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyShop.data.ModelViews
{
    public class MVIndex : IBrand, IProducts
    {
        public MVIndex(IEnumerable<ProductModel> products, IEnumerable<BrandModel> brands)
        {
            this.products = products;
            this.brands = brands;
        }

        IEnumerable<ProductModel> _products;
        public IEnumerable<ProductModel> products
        { 
            get => _products;
            set => _products = value.Where(p => Convert.ToBoolean(p.Characteristics["Novelty"]));
        }
        public IEnumerable<BrandModel> brands { get; set; }
    }
}
