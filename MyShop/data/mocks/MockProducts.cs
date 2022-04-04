using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.mocks
{
    public class MockProducts : IProducts
    {
        private readonly ICategory _category = new MockCategory();

        public IEnumerable<Product> products { 
            get {
                return new List<Product>
                {
                    new Product{ Id=1, Name="Ноутбук", Brand="BTest", Price=414999, Availability=10, Category =  _category.categories.FirstOrDefault(c => c.Id == 1), Img="laptop.png" },
                    new Product{ Id=2, Name="Колонка", Brand="BTest", Price=49999, Availability=10, Category =  _category.categories.FirstOrDefault(c => c.Id == 2), Img="musical_column.png" },
                    new Product{ Id=3, Name="Мышка игровая", Brand="BTest", Price=13999, Availability=10, Category =  _category.categories.FirstOrDefault(c => c.Id == 3), Img="gamingmaus.png" },
                    new Product{ Id=4, Name="Мышка офисная", Brand="BTest", Price=199, Availability=10, Category =  _category.categories.FirstOrDefault(c => c.Id == 3), Img="officemause.png" }

                };
            } 
            set => throw new System.NotImplementedException(); }
    }
}
