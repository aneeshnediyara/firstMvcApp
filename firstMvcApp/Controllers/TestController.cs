using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstMvcApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(string id = "")
        {
            ViewBag.Id = String.IsNullOrEmpty(id) ? "EMPTY" : id;
            return View();
        }
    }
}