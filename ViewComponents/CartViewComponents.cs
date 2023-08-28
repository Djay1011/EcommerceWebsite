using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppli.Helpers;
using WebAppli.Models;

namespace WebAppli.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponents : ViewComponent
    {
        
    public async Task<IViewComponentResult> InvokeAsync()
        {
            string cart = HttpContext.Session.GetString("ShoppingCart");
            ViewBag.Total = 0;
            if (cart != null)
            {
                List<Item> MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
                ViewBag.Total = MyCart.Sum(it => it.product.Price * it.Quantity);
                ViewBag.CountItems = MyCart.Count;
            }
            return View("Index");
        }
    }
}
