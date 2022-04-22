using MyShop.data.interfaces;
using MyShop.data.Models.Brand;
using System.Collections.Generic;

namespace MyShop.data.mocks
{
    public class MockBrand : IBrand
    {
        public IEnumerable<BrandModel> brands { 
            get {
                return new List<BrandModel>
                {
                    new BrandModel { Id=1, Name="Apple", Img="Apple.jpg" },
                    new BrandModel { Id=2, Name="Samsung", Img="Samsung.jpg" },
                };
            }
            set => throw new System.NotImplementedException(); }
    }
}
