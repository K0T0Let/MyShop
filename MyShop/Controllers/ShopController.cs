using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.data.DB;
using MyShop.data.Interfaces;
using MyShop.data.ModelViews;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MyShop.data.Models;
using System.Collections.Generic;
using System;

namespace MyShop.Controllers
{
    public class ShopController : Controller
    {
        public readonly ShopDBContext shopDBContext;
        public readonly IBrand brand;
        public readonly IProduct product;
        public readonly IAssembly assembly;
        public readonly IColor color;
        public readonly IImage image;
        public readonly IProperty property;
        public readonly ICategory_property category_Property;
        public readonly IСharacteristicsFilter сharacteristicsFilter;

        public ShopController(
            ShopDBContext shopDBContext, 
            IBrand brand, 
            IProduct product, 
            IAssembly assembly,
            IColor color,
            IImage image,
            IProperty property,
            ICategory_property category_Property,
            IСharacteristicsFilter сharacteristicsFilter)
        {
            this.shopDBContext = shopDBContext;
            this.brand = brand;
            this.product = product;
            this.assembly = assembly;
            this.color = color;
            this.image = image;
            this.property = property;
            this.category_Property = category_Property;
            this.сharacteristicsFilter = сharacteristicsFilter;
        }

        public IActionResult Index()
        {
            MVIndex model = new MVIndex(assembly.Assemblies, brand.Brands);
            return View(model);
        }

        [HttpGet]
        public IActionResult Section(uint id)
        {
            //Сортировка сборок
            List<Assembly> SortAssembly = assembly.Assemblies.Where(a => a.Product.BrandId == id).ToList()             
                .OrderByDescending(sa => sa.Connections.FirstOrDefault(c => c.PropertyId == 1).Meaning)
                .ThenBy(sa => sa.ColorId)
                .ThenBy(sa => int.Parse(sa.Connections.FirstOrDefault(c => c.PropertyId == 3).Meaning)).ToList();

            MVSection model = new MVSection(
                SortAssembly,
                HttpContext.Request.Query,
                сharacteristicsFilter
                );
            return View(model);
        }

        public IActionResult Element(uint id)
        {
            var item1 = assembly.Assemblies.FirstOrDefault(a => a.Id == id);
            var item2 = assembly.Assemblies.Where(a => a.Product.Id == item1.Product.Id).ToList();
            return View(new MVElement(item1, item2));
        }


        /*public IActionResult Index()
        {
            AllModels model = new AllModels { products = _products.products, categories = _category.categories };
            if (HttpContext.Session.Keys.Contains("order"))
            {
                Order order = HttpContext.Session.Get<Order>("order");
                ViewBag.OrderCount = 0;
                foreach (var item in order.products)
                    ViewBag.OrderCount += item.AvailabilityOrder;
            }
                
            return View(model);
        }

        public IActionResult Order()
        {
            if (HttpContext.Session.Keys.Contains("order"))
            {
                Order order = HttpContext.Session.Get<Order>("order");
                ViewBag.OrderCount = 0;
                foreach (var item in order.products)
                    ViewBag.OrderCount += item.AvailabilityOrder;
                return View(order);
            }
            else
            {
                return View();
            }

        }

        public IActionResult AddOrder(int ProductId)
        {
            Product product = _products.products.FirstOrDefault(p => p.Id == ProductId);

            if (HttpContext.Session.Keys.Contains("order"))
            {
                Order order = HttpContext.Session.Get<Order>("order");
                if (order.products.FirstOrDefault(p => p.Id == ProductId) != null)
                {
                    order.products.FirstOrDefault(p => p.Id == ProductId).AvailabilityOrder++;
                }
                else
                {
                    product.AvailabilityOrder = 1;
                    order.products.Add(product);
                }

                order.Price += product.Price;
                HttpContext.Session.Set<Order>("order", order);
            }
            else
            {
                Order order = new Order();
                product.AvailabilityOrder = 1;
                order.products = new List<Product> { product };
                order.Price = product.Price;
                HttpContext.Session.Set<Order>("order", order);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DelOrder(int ProductId)
        {
            Order order = HttpContext.Session.Get<Order>("order");
            
            foreach(var item in order.products)
            {
                if(item.Id == ProductId)
                {
                    order.products.Remove(item);
                    order.Price -= item.Price;
                    break;
                }
            }

            if (order.products.Count == 0)
                HttpContext.Session.Remove("order");
            else
                HttpContext.Session.Set<Order>("order", order);
            return RedirectToAction("Order");
        }

        public IActionResult AllDelOrder()
        {
            HttpContext.Session.Remove("order");
            return RedirectToAction("Order");
        }*/
    }
}
