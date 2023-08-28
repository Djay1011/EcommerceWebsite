using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;
using Microsoft.EntityFrameworkCore;
using WebAppli.Helpers;
using System.Xml.Schema;
using System.Linq;

namespace WebAppli.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private DatabaseContext _db;

        public List<Item> MyCart;

        public decimal SubTotal { get; set; }
        public decimal Tax { get; internal set; }
        public decimal tax { get; set; }
        public decimal Total { get; set; }

        public ShoppingCartModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            string cart = HttpContext.Session.GetString("ShoppingCart");
            Total = 0;
            if (cart != null)
            {
                MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
                SubTotal = MyCart.Sum(it => it.product.Price * it.Quantity);
                Tax = 0.1m;
                tax = MyCart.Sum(it => it.product.Price * it.Quantity * Tax);
                Total = MyCart.Sum(it => it.product.Price * it.Quantity * (1 + Tax));
            }
            

        }

        public IActionResult OnPost(int[] quantity) 
        {
            List<Item> items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
            for(int i = 0; i < quantity.Length; i++)
            {
                items[i].Quantity = quantity[i];
            }
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnGetRemove(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
            var index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ShoppingCart", (cart));
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnGetCheckout()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                var account = _db.Accounts.AsNoTracking().SingleOrDefault(a => a.UserName == (username));
                var invoice = new Invoice
                {
                    Created = DateTime.Now,
                    Name = "Online Invoice",
                    Status = 1,
                    AccountId = account.Id
                };
                _db.Invoices.Add(invoice);
                _db.SaveChanges();


                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
                if (cart != null)
                {
                    foreach(var item in cart)
                    {
                        var invoiceDetails = new InvoiceDetail
                        {
                            InvoiceId = invoice.Id,
                            ProductId = item.product.Id,
                            Price = item.product.Price,
                            Quantity = item.Quantity
                        };
                        _db.InvoiceDetails.Add(invoiceDetails);
                        _db.SaveChanges();
                    }
                }
                return RedirectToPage("Thanks");
            }
        }

        public IActionResult OnGetBuyNow(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "ShoppingCart");
            Products product = _db.Product.SingleOrDefault(p => p.Id == id);
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    product = new ProductCart
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price, 
                        Photo = product.photo
                    },
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ShoppingCart", (cart));
            }
            else
            {
                var index = Exists(cart, id);
                if(index == -1)
                {
                    cart.Add(new Item()
                    {
                        product = new ProductCart
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Photo = product.photo
                        },
                        Quantity = 1
                    });
                }
                else
                {
                    var newQuantity = cart[index].Quantity +1;
                    cart[index].Quantity = newQuantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ShoppingCart", (cart));
            }
            return RedirectToPage("ShoppingCart");
        }

        private int Exists(List<Item> cart, int id)
        {
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
        
}
