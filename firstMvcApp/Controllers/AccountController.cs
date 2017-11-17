using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstMvcApp.Infrastructure;
using firstMvcApp.Models;

namespace firstMvcApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        IAuthProvider authProvider;
        public AccountController(IAuthProvider provider)
        {
            authProvider = provider;
        }
        public ActionResult login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
       
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password, model.RememberMe))
                {
                    Session["IsAutenticated"] = true;
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Bad username/password.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}