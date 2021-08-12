using esitem.Entity;
using esitem.Identity;
using esitem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace esitem.Controllers
{
    
    public class AccountController : Controller
    {
        DataContext db = new DataContext();

        



        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

   

        // GET: Account


        public PartialViewResult UserCount()
        {
            var u = UserManager.Users;
            return PartialView(u);
        }

        public ActionResult UserList()
        {
            var u = UserManager.Users;

            return View(u);
            
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }
            return View(model);
           

        }
    


        public ActionResult UserProfil()

        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new UserProfile()
            {
                id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Username = user.UserName
            };
            return View(data);

            
        }


        [HttpPost]
        public ActionResult UserProfil(UserProfile model)


        {
            var user = UserManager.FindById(model.id);
            user.Name = model.Name;
                user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.Username;
            UserManager.Update(user);

            return View("Update");
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Anasayfa");
        }



        [HttpPost]
        public ActionResult Login(Login model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                if (user!=null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var Identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, Identityclaims);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    TempData["LoginUserError"] = "Kullanıcı Adınız Veya Şifreniz Yanlış Lütfen Tekrar Giriniz";

                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                var result = UserManager.Create(user, model.Password);
                if(result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluştuma Hatası....");
                }

            }
            return View(model);



        }
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrder
            {

                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                OrderDate = i.OrderDate,
                Total = i.Total,
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()

            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {

                    ÜrünId = x.ÜrünId,
                    Image = x.Ürün.İmage,
                    Ürünİsmi = x.Ürün.Name,
                    Quantity = x.Quantity,
                    Price = x.Price

                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }

        public ActionResult sifreunuttum()
        {
        
            return View();
        }

     

    }
}