using dailybook.Areas.Admin.Models.Authentication;
using dailybook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json.Linq;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace dailybook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    [Authentication]
    public class HomeController : Controller
    {
        DailybookContext db = new DailybookContext();
        //[Route("")]
        //[Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("category")]

        public IActionResult Category(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstProduct = db.Categories.AsNoTracking().OrderBy(x => x.CatName);
            PagedList<Category> lst = new PagedList<Category>(lstProduct, pageNumber, pageSize);
            return View(lst);
        }

        [Route("Create")]
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(Cat);
                db.SaveChanges();
                return RedirectToAction("category");
            }
            return View(Cat);
        }

        [Route("Update")]
        [HttpGet]

        public IActionResult Update(int CatId)
        {
            var cat = db.Categories.Find(CatId);
            return View(cat);
        }

        [Route("Update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category Cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("category");
            }
            return View(Cat);
        }

        [Route("Delete")]
        [HttpGet]
        public IActionResult Delete(int CatId)
        {
            TempData["Message"] = "";
            var countProduct = db.Products.Where(x => x.CatId == CatId).ToList();
            if (countProduct.Count > 0)
            {
                TempData["Message"] = "Cannot delete this category";
                return RedirectToAction("category");
            }
            db.Remove(db.Categories.Find(CatId));
            db.SaveChanges();
            TempData["Message"] = "The category has been successfully deleted";
            return RedirectToAction("category");
        }

        [Route("CategoryDetail")]
        public async Task<IActionResult> CategoryDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await db.Categories
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }


        [Route("product")]
        public IActionResult Product(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstProduct = db.Products.AsNoTracking().OrderBy(x => x.ProductId);
            PagedList<Product> lst = new PagedList<Product>(lstProduct, pageNumber, pageSize);
            return View(lst);
        }
        [Route("CreateProduct")]
        [HttpGet]

        public IActionResult CreateProduct()
        {
            ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "CatId");
            return View();
        }

        [Route("CreateProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            return View(product);
        }

        [Route("UpdateProduct")]
        [HttpGet]

        public IActionResult UpdateProduct(int ProductId)
        {
            ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "CatId");
            var product = db.Products.Find(ProductId);
            return View(product);
        }

        [Route("UpdateProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Product Pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("product");
            }
            return View(Pro);
        }

        [Route("DeleteProduct")]
        [HttpGet]
        public IActionResult DeleteProduct(int ProductId)
        {
            TempData["Message"] = "";
            var countProduct = db.OrderDetails.Where(x => x.ProductId == ProductId).ToList();
            if (countProduct.Count > 0)
            {
                TempData["Message"] = "Cannot delete this product";
                return RedirectToAction("product");
            }
            db.Remove(db.Products.Find(ProductId));
            db.SaveChanges();
            TempData["Message"] = "The product has been successfully deleted";
            return RedirectToAction("product");
        }

        [Route("ProductDetail")]
        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "CatName");
            return View(product);

            //ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "CatName");
            //var product = await db.Products
            //    .Include(p => p.Cat)
            //    .FirstOrDefaultAsync(m => m.ProductId == id);
            //return View(product);
        }


        [Route("order")]
        public IActionResult Order(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstOrder = db.Orders.AsNoTracking().OrderBy(x => x.OrderId);
            PagedList<Order> lst = new PagedList<Order>(lstOrder, pageNumber, pageSize);
            return View(lst);
        }

        [Route("CreateOrder")]
        [HttpGet]

        public IActionResult CreateOrder()
        {
            ViewBag.CusId = new SelectList(db.Customers.ToList(), "CusId", "CusId");
            ViewBag.TransactStatusId = new SelectList(db.TransactStatuses.ToList(), "TransactStatusId", "TransactStatusId");
            return View();
        }

        [Route("CreateOrder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(Order ord)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(ord);
                db.SaveChanges();
                return RedirectToAction("order");
            }
            return View(ord);
        }

        [Route("UpdateOrder")]
        [HttpGet]

        public IActionResult UpdateOrder(int OrderId)
        {
            ViewBag.CusId = new SelectList(db.Customers.ToList(), "CusId", "CusId");
            ViewBag.TransactStatusId = new SelectList(db.TransactStatuses.ToList(), "TransactStatusId", "TransactStatusId");
            var order = db.Orders.Find(OrderId);
            return View(order);
        }

        [Route("UpdateOrder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOrder(Order ord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Order");
            }
            return View(ord);
        }

        [Route("DeleteOrder")]
        [HttpGet]
        public IActionResult DeleteOrder(int OrderId)
        {
            TempData["Message"] = "";
            var status = db.TransactStatuses.SingleOrDefault(status => status.Orders.Any(order => order.OrderId == OrderId));
            var statusId = status.TransactStatusId;
            // status Id = 5 => don hang bi cancelled, chi co don hang bi cancelled moi xoa duoc
            if (statusId != 5)
            {
                TempData["Message"] = "Cannot delete this order";
                return RedirectToAction("order");
            }
            var details = db.OrderDetails.Where(x => x.OrderId == OrderId).ToList();
            db.RemoveRange(details);
            db.Remove(db.Orders.Find(OrderId));
            db.SaveChanges();
            TempData["Message"] = "The order has been successfully deleted";
            return RedirectToAction("order");
        }

        [Route("OrderDetail")]
        public async Task<IActionResult> OrderDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.Orders
                .Include(p => p.TransactStatus)
                .Include(x => x.Cus)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.CusId = new SelectList(db.Customers.ToList(), "CusId", "Fullname");
            ViewBag.TransactStatusId = new SelectList(db.TransactStatuses.ToList(), "TransactStatusId", "Status");
            return View(order);
        }
    }
}
