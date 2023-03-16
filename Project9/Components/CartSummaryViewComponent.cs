using Microsoft.AspNetCore.Mvc;
using Project9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project9.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public CartSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
