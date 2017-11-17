using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcApp.Models;
using firstMvcApp.Infrastructure;
using System.Web.Mvc;

namespace firstMvcApp.Controllers
{
    public class CartController : Controller
    {
        IRepository<Category, int> _categories;
        IRepository<Product, int> _products;
        CartViewModel viewModel;

        public CartController(
            IRepository<Category, int> categories, IRepository<Product, int> products)
        {
            _categories = categories;
            _products = products;
            viewModel = new CartViewModel();
        }
        public ActionResult Index(String selectedcategory)
        {
            viewModel = new CartViewModel
            {
                SelectedCategory = selectedcategory,
                Categories = _categories.GetAll(),
                Products = _products.GetAll().Where(p=>p.CategoryId == Convert.ToInt32(selectedcategory)).ToList()
            };
            return View(viewModel);
        }

        public ActionResult GetProducts(string id = "0")
        {
            var products = _products.GetAll();
            var catId = Convert.ToInt32(id);
            var filteredProducts =
                from p in products
                where p.CategoryId == catId
                select p;
            return Json(filteredProducts.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductCategory(String selectedCategory = "0")
        {
           var products = _products.GetAll();
           return PartialView(products);
        }
    }
}