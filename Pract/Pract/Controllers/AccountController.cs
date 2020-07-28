using Pract.Models;
using Pract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Pract.Controllers
{
    public class AccountController : Controller
    {
        Hash h = new Hash();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using(UserContext db=new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    using(UserContext db=new UserContext())
                    {
                        db.Users.Add(new Models.User { Email = model.Name, Password = h.GetHashMD5(model.Password) });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Email == model.Name).FirstOrDefault();
                    }
                    if(user!=null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, false);
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using(UserContext db=new UserContext())
                {
                    string checkPassword = h.GetHashMD5(model.Password);
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == checkPassword);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }
            return View(model); 
        }
    }
}