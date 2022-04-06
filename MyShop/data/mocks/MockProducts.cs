using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.mocks
{
    public class MockProducts : IProducts
    {
        private readonly IBrand _brands = new MockBrand();
        public IEnumerable<Product> products { 
            get {
                return new List<Product>
                {
                    new Product { Id = 1, Name = "iPhone 13 Pro", BrandId = 1, Novelty = true, Price=224990, Img="iPhone 13 Pro.jpg", brand = _brands.brands.FirstOrDefault(b => b.Id == 1) },
                    new Product { Id = 2, Name = "iPhone 13", BrandId = 1, Novelty = true, Price=115990, Img="iPhone 13.jpg", brand = _brands.brands.FirstOrDefault(b => b.Id == 1) },
                    new Product { Id = 3, Name = "iPhone SE", BrandId = 1, Novelty = true, Price=52990, Img="iPhone SE.jpg", brand = _brands.brands.FirstOrDefault(b => b.Id == 1)},
                    new Product { Id = 4, Name = "iPhone 12", BrandId = 1, Novelty = true, Price=84990, Img="iPhone 12.jpg", brand = _brands.brands.FirstOrDefault(b => b.Id == 1) },
                    new Product { Id = 5, Name = "iPhone 11", BrandId = 1, Novelty = true, Price=59990, Img="iPhone 11.jpg", brand = _brands.brands.FirstOrDefault(b => b.Id == 1) },
                    new Product { Id = 6, Name = "Galaxy Z Fold3", BrandId = 2, Novelty = true, Price=165290, Img="Galaxy Z Fold3.png", brand = _brands.brands.FirstOrDefault(b => b.Id == 2) },
                    new Product { Id = 7, Name = "Galaxy S21+ 5G", BrandId = 2, Novelty = true, Price=96260, Img="Galaxy S21 plus 5G.jfif", brand = _brands.brands.FirstOrDefault(b => b.Id == 2) },
                    new Product { Id = 8, Name = "Galaxy A22s 5G", BrandId = 2, Novelty = true, Price=27290, Img="Galaxy A22s 5G.png", brand = _brands.brands.FirstOrDefault(b => b.Id == 2)},
                    new Product { Id = 9, Name = "Galaxy S22 Ultra", BrandId = 2, Novelty = true, Price=149990, Img="Galaxy S22 Ultra.png", brand = _brands.brands.FirstOrDefault(b => b.Id == 2) },
                    new Product { Id = 10, Name = "Galaxy S20 FE", BrandId = 2, Novelty = true, Price=46630, Img="Galaxy S20 FE.jfif", brand = _brands.brands.FirstOrDefault(b => b.Id == 2) },                };
            } 
            set => throw new System.NotImplementedException(); }
    }
}
