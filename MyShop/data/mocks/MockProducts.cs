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
                    new Product
                    {
                        Id = 1,
                        Characteristics = new СharacteristicsProduct
                        {
                            Availability = 10,
                            Novelty = false,
                            Price = 69990,
                            ModelName = "iPhone 12",
                            BrandId = 1,
                            Brand = _brands.brands.FirstOrDefault(b => b.Id == 1),
                            RAMMemory = 4,
                            ROMMemory = 64,
                            BatteryCapacity = 2815,
                            Diagonal = 6.1,
                            Core = 6,
                            SIMCard = 1,
                            Color = new ProductColor
                            {
                                Name = "Black",
                                RGBCode = "#000000"
                            }
                        },
                        Img = new ProductImg
                        {
                            ImgPreview = "iPhone 12 Black.png",
                            ImgProduct = new List<string>
                            {
                                "iPhone 12 Black.png",
                            }
                        }
                    },

                    new Product
                    {
                        Id = 2,
                        Characteristics = new СharacteristicsProduct
                        {
                            Availability = 10,
                            Novelty = true,
                            Price = 115990,
                            ModelName = "iPhone 13",
                            BrandId = 1,
                            Brand = _brands.brands.FirstOrDefault(b => b.Id == 1),
                            RAMMemory = 4,
                            ROMMemory = 512,
                            BatteryCapacity = 3265,
                            Diagonal = 6.1,
                            Core = 6,
                            SIMCard = 1,
                            Color = new ProductColor
                            {
                                Name = "White",
                                RGBCode = "#FFFFFF"
                            }
                        },
                        Img = new ProductImg
                        {
                            ImgPreview = "iPhone 13 White.png",
                            ImgProduct = new List<string>
                            {
                                "iPhone 13 White.png",
                            }
                        }
                    },

                    new Product
                    {
                        Id = 3,
                        Characteristics = new СharacteristicsProduct
                        {
                            Availability = 10,
                            Novelty = true,
                            Price = 94990,
                            ModelName = "iPhone 13",
                            BrandId = 1,
                            Brand = _brands.brands.FirstOrDefault(b => b.Id == 1),
                            RAMMemory = 4,
                            ROMMemory = 128,
                            BatteryCapacity = 3265,
                            Diagonal = 6.1,
                            Core = 6,
                            SIMCard = 1,
                            Color = new ProductColor
                            {
                                Name = "White",
                                RGBCode = "#FFFFFF"
                            }
                        },
                        Img = new ProductImg
                        {
                            ImgPreview = "iPhone 13 White.png",
                            ImgProduct = new List<string>
                            {
                                "iPhone 13 White.png",
                            }
                        }
                    },

                    new Product
                    {
                        Id = 4,
                        Characteristics = new СharacteristicsProduct
                        {
                            Availability = 0,
                            Novelty = true,
                            Price = 179990,
                            ModelName = "Galaxy Z Fold3 5G",
                            BrandId = 2,
                            Brand = _brands.brands.FirstOrDefault(b => b.Id == 2),
                            RAMMemory = 12,
                            ROMMemory = 256,
                            BatteryCapacity = 4400,
                            Diagonal = 7.6,
                            Core = 8,
                            SIMCard = 2,
                            Color = new ProductColor
                            {
                                Name = "Phantom Black",
                                RGBCode = "#000000"
                            }
                        },
                        Img = new ProductImg
                        {
                            ImgPreview = "Galaxy Z Fold3 Phantom Black.png",
                            ImgProduct = new List<string>
                            {
                                "Galaxy Z Fold3 Phantom Black.png",
                            }
                        }
                    },

                    new Product
                    {
                        Id = 5,
                        Characteristics = new СharacteristicsProduct
                        {
                            Availability = 10,
                            Novelty = false,
                            Price = 18250,
                            ModelName = "Galaxy A22s 5G",
                            BrandId = 2,
                            Brand = _brands.brands.FirstOrDefault(b => b.Id == 2),
                            RAMMemory = 4,
                            ROMMemory = 64,
                            BatteryCapacity = 5000,
                            Diagonal = 6.6,
                            Core = 8,
                            SIMCard = 2,
                            Color = new ProductColor
                            {
                                Name = "Mint",
                                RGBCode = "#d6e8dd"
                            }
                        },
                        Img = new ProductImg
                        {
                            ImgPreview = "Galaxy A22s 5G Mint.png",
                            ImgProduct = new List<string>
                            {
                                "Galaxy A22s 5G Mint.png",
                            }
                        }
                    }
                };
            } 
            set => throw new System.NotImplementedException(); }
    }
}
