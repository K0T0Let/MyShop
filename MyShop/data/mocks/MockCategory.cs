using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> categories { 
            get {
                return new List<Category>
                {
                    new Category { Id=1, Name="Ноутбуки" },
                    new Category { Id=2, Name="Колонки" },
                    new Category { Id=3, Name="Мышки" }
                };
            }
            set => throw new System.NotImplementedException(); }
    }
}
