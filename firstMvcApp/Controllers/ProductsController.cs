using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstMvcApp.Infrastructure;
using firstMvcApp.Models;

namespace firstMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        IRepository<Product, int> _repository;
        public ProductsController(IRepository<Product, int> repository)
        {
            // _repository = new ProductRepository();
            _repository = repository;
        }
        // GET: Products
        public ActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }
        public ActionResult Details(int id = 0)
        {
            var model = _repository.GetDetails(id);
            return View(model);
        }
        public ActionResult Edit(int id = 0)
        {
            var model = _repository.GetDetails(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product item)
        {
            try
            {
                _repository.Update(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult Create(int id = 0)
        {            
            return View();
        }
        [HttpPost]
        //public ActionResult Create(Product item)
        //{
        //    try
        //    {
        //        _repository.Create(item);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View("Error");
        //    }
        //}
        //public ActionResult Create(FormCollection collection)
        // {
        //     try
        //     {
        //         var item = new Product();
        //         /* item.ProductName = Request.Form["ProductName"];
        //          item.UnitPrice = Convert.ToDecimal(Request.Form["UnitPrice"]);
        //          item.UnitsInStock = Convert.ToInt16(Request.Form["UnitInStock"]);
        //          item.Discontinued = Convert.ToBoolean(Request.Form["Discontinued"]);*/
        //         var name = collection["ProductName"];
        //         if (string.IsNullOrEmpty(name))
        //         {
        //             ModelState.AddModelError("ProductName", "Product Name is required.");
        //             return View();
        //         }
        //         else
        //             ModelState.AddModelError("ProductName", "");

        //         item.ProductName = collection["ProductName"];
        //         item.UnitPrice = Convert.ToDecimal(collection["UnitPrice"]);
        //         item.UnitsInStock = Convert.ToInt16(collection["UnitInStock"]);
        //         item.Discontinued = Convert.ToBoolean(collection["Discontinued"]);

        //         _repository.Create(item);
        //         return RedirectToAction("Index");
        //     }
        //     catch (Exception ex)
        //     {
        //         return View("Error");
        //     }
        // } 

        public ActionResult Create(Product item )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Create(item);
                    return RedirectToAction("Index");
                }
                else
                    return View();              
                 
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            try
            {
                var model = _repository.GetDetails(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Delete(Product item)
        {
            try
            {
                _repository.Delete(item.ProductId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}