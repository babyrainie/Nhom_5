using dailybook.Models;
using Microsoft.AspNetCore.Mvc;
using dailybook.Helpers;
using dailybook.ViewModels;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace dailybook.Controllers
{
    public class CartController : Controller
    {
        private readonly DailybookContext db;

        public CartController(DailybookContext context)
        {
            db = context;
        }
        //const string CART_KEY = "MYCART";
        public List<ViewModels.CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var MyCart = Cart;
            var item = MyCart.SingleOrDefault(p => p.ProductId == id);
            if (item == null)
            {
                var MyProducts = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (MyProducts == null)
                {
                    TempData["Message"] = "Not found";
                    return Redirect("/404");
                }

                item = new CartItem
                {
                    ProductId = MyProducts.ProductId,
                    ProductName = MyProducts.ProductName,
                    Price = MyProducts.Price ?? 0,
                    Image = MyProducts.Thumb ?? string.Empty,
                    Quantity = quantity
                };
                MyCart.Add(item);
            }
            else
            {
                item.Quantity += quantity;

            }
            HttpContext.Session.Set(MySetting.CART_KEY, MyCart);
            HttpContext.Session.Set<List<CartItem>>("GioHang", MyCart);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCart(int id)
        {
            var MyCart = Cart;
            var item = MyCart.SingleOrDefault(p => p.ProductId == id);
            if (item != null)
            {
                MyCart.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, MyCart);
                HttpContext.Session.Set<List<CartItem>>("GioHang", MyCart);
            }
            return RedirectToAction("Index");
        }
    }
}
