using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebClient client = new WebClient();
            var result = client.DownloadString("http://localhost:52599/api/products");
            var products = JsonSerializer.Create().Deserialize(new JsonTextReader(new StringReader(result)), typeof(List<Products>));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}