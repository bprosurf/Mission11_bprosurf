using Microsoft.AspNetCore.Mvc;
using Project9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project9.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Buy());
        }

        [HttpPost]
        public IActionResult Checkout(Buy buy)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                buy.Lines = basket.Items.ToArray();
                repo.SaveBuy(buy);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
