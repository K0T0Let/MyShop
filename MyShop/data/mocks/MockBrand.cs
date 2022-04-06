using MyShop.data.interfaces;
using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.mocks
{
    public class MockBrand : IBrand
    {
        public IEnumerable<Brand> brands { 
            get {
                return new List<Brand>
                {
                    new Brand { Id=1, Name="Apple", Img="Apple.jpg" },
                    new Brand { Id=2, Name="Samsung", Img="Samsung.jpg" },
                };
            }
            set => throw new System.NotImplementedException(); }
    }
}
