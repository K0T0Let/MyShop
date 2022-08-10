using Microsoft.AspNetCore.Mvc;
using MyShop.data.ModelViews;
using System.Collections.Generic;

namespace MyShop.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Order()
        {
            return View(new MVProfile());
        }

        public IActionResult Wishlist()
        {
            return View(new MVProfile());
        }

        public IActionResult Bonuses()
        {
            return View(new MVProfile());
        }

        public IActionResult Settings()
        {
            return View(new MVProfile());
        }
    }
}
