using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppli.Helpers;
using WebAppli.Models;

namespace WebAppli.ViewComponents
{
    [ViewComponent(Name = "Nav")]
    public class NavViewComponents : ViewComponent
    {

        private DatabaseContext _db;

        public NavViewComponents(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var category = await _db.Category.FindAsync(categoryId);
            return View("Index");
        }

    }
}
