using System.Security.Claims;
using dailybook.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
//using dailybook.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace dailybook.Controllers
{
    [Area("admin")]
    [Route("admin")]
    //[Route("admin/homeadmin")]
    public class AccessController : Controller
    {
        DailybookContext db = new DailybookContext();
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(Account user)
        {
            var u = db.Accounts.Where(x => x.Email.Equals(user.Email) && x.Pass.Equals(user.Pass)).FirstOrDefault();
            if (u != null)
            {
                HttpContext.Session.SetString("Username", u.Email.ToString());
                return RedirectToAction("Index", "Home", new { Areas = "Admin" });
            }
            return View();
        }

    }
}
        //[HttpGet]
        //public IActionResult Login(string? ReturnURL)
        //{
        //    ViewBag.ReturnURL = ReturnURL;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginAdminVM model)
        //{
        //    //ViewBag.ReturnURL = ReturnURL;
        //    if (ModelState.IsValid)
        //    {
        //        var account = db.Accounts.SingleOrDefault(cus => cus.Email == model.Email);
        //        if (account == null)
        //        {
        //            ModelState.AddModelError("Error", "Customer not found");
        //        }
        //        else
        //        {
        //            if (!account.Active)
        //            {
        //                ModelState.AddModelError("Error", "Account is not active");
        //            }
        //            else
        //            {
        //                //if (customer.Pass != model.Password.ToMd5Hash(customer.Salt))
        //                if (account.Pass != model.Password)
        //                {
        //                    ModelState.AddModelError("Error", "Incorrect Password");
        //                }
        //                else
        //                {
        //                    var claims = new List<Claim> {
        //                        new Claim(ClaimTypes.Email,account.Email),
        //                        new Claim(ClaimTypes.Name,account.Fullname),
        //                        new Claim("AccountId", account.AccountId.ToString()),
        //                        new Claim(ClaimTypes.Role, account.Role.RoleName)
        //                    };
        //                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        //                    await HttpContext.SignInAsync(claimsPrincipal);
        //                    TempData["message"] = "Sign in sucessfully";
        //                    //object value = _notyfService.Login("Đăng nhập thành công");

        //                    return RedirectToAction("Index", "Home", new { Areas = "Admin" });
        //                }
        //            }
        //        }
        //    }
        //    return View(model);
        //}
    //}
//}
