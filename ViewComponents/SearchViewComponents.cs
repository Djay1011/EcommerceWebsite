using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppli.Helpers;
using WebAppli.Models;

namespace WebAppli.ViewComponents
{
    [ViewComponent(Name = "SearchBar")]
    public class SearchViewComponents : ViewComponent
    {

        private DatabaseContext _db;

        public SearchViewComponents(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }

    }
}
