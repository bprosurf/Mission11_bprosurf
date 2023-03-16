using Microsoft.AspNetCore.Mvc;
using Project9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project9.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        private Basket basket;

        public TypesViewComponent (IBookstoreRepository temp, Basket basketService)
        {
            repo = temp;
            basket = basketService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }

    }
}
