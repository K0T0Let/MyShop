﻿using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.ModelViews
{
    public class ModelViewIndex : IBrand, IProducts
    {
        IEnumerable<Product> _products;
        public IEnumerable<Product> products
        { 
            get 
            {
                return _products;
            }
            set 
            {
                _products = value.Where(p => p.Novelty == true);
            }
        }
        public IEnumerable<Brand> brands { get; set; }
    }
}