using firstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstMvcApp.Infrastructure;

namespace firstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository<SampleModel, int> repository;
        public HomeController()
        {
            repository = new SampleModleRepository();
        }
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();

        }
        [Route ("ConnectToUs")] //http://localhost:XXXX/connecttous
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string ExampleAction()
        {
            return "Welcome to ASP.Net MVC Env.";
        }

        public JsonResult GetJSON()
        {
            var obj = new { ID=123, Name = "CGI"};
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        /*JSON Format: {"Property":"value, "property":"value"}*/

        public ActionResult ModelAction(int id = 0)
        {
            //var model = new SampleModel { Id = 1510, Name = "CGI" };
            //var model = new { Id = 1510, Name = "CGI" };
            var model = repository.GetDetails(id);
            return View(model);
        }
        
       
    }
}