using System.Collections.Generic;

namespace MyShop.data.ModelViews
{
    public class MVProfile
    {
        public Dictionary<string, string> SectionList = new Dictionary<string, string>()
        {
            ["Order"] = "Заказы",
            ["Wishlist"] = "Избранное",
            ["Bonuses"] = "Баллы",
            ["Settings"] = "Настройки профиля"
        };
    }
}
