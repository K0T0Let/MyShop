using MyShop.data.Models;
using System.Collections.Generic;

namespace MyShop.data.Filter.FiltrationTypes
{
    public class FiltrationEvent
    {
        public delegate bool Request(Assembly a, int k, List<ItemSpecifications> f);
        event Request request;

        public FiltrationEvent(Request request) => this.request = request;

        public bool ActionRequest(Assembly a, int k, List<ItemSpecifications> f)
        {
            return request(a, k, f);
        }
    }
}
