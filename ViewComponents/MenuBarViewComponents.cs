using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppli.ViewComponents
{
    [ViewComponent(Name = "MenuBar")]
    public class MenuBarViewComponents : ViewComponent
    {
        public string usernameSession { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.usernameSession = HttpContext.Session.GetString("username");
            return View("Index");
        }
    }
}
