using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.data.interfaces;
using MyShop.data.ModelViews;

namespace MyShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProducts _products;
        private readonly IBrand _brand;
        private readonly IСharacteristicsFilter _characteristicsFilter;

        public ShopController(IProducts products, IBrand brand, IСharacteristicsFilter characteristicsFilter)
        {
            _products = products;
            _brand = brand;
            _characteristicsFilter = characteristicsFilter;
        }

        public IActionResult Index()
        {
            MVIndex model = new MVIndex(_products.products, _brand.brands);
            return View(model);
        }

        [HttpGet]
        public IActionResult Section(uint id)
        {
            MVSection model = new MVSection(
                id, 
                _brand.brands, 
                HttpContext.Request.Query, 
                _products.products, 
                _characteristicsFilter.characteristics
                );
            return View(model);


            /*if (HttpContext.Request.QueryString.ToString() == "")
            {
                ModelViewSection model = new ModelViewSection(id, _products.products, _characteristicsFilter.characteristics);
                return View(model);
            }
            else
            {
                ModelViewSection model = new ModelViewSection(id, HttpContext.Request.Query, _products.products, _filter.сharacteristicsFilters);
                return View(model);

                string result = HttpContext.Request.Query["ModelName-1"].ToString();
                if (HttpContext.Request.Query["ModelName-1"] == "")
                    result = "false";
                return Content(result);
            }*/
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
