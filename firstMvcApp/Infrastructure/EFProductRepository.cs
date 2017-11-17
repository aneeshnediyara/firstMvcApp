using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcApp.Models;

namespace firstMvcApp.Infrastructure
{
    public class EFProductRepository : IRepository<Product, int>
    {
        NorthwindContext db;
        public EFProductRepository() 
        {
            db = new NorthwindContext();
        }
        public void Create(Product item)
        {
            var product = db.Products.FirstOrDefault(c => c.ProductName==item.ProductName);
            if (product == null)
            {
                db.Products.Add(item);
                db.SaveChanges();
            }
            else
                throw new ArgumentNullException("Requested item not found. Create");
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Requested item not found. Delete");
            }
        }
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetDetails(int id)
        {
            return db.Products.FirstOrDefault(c => c.ProductId == id);
        }

        public void Update(Product item)
        {
            var product = db.Products.Find(item.ProductId);
            if (product != null)
            {
                product.ProductName = item.ProductName;
                product.UnitPrice = item.UnitPrice;
                product.UnitsInStock = item.UnitsInStock;
                product.Discontinued = item.Discontinued;

                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
                throw new ArgumentNullException("Requested item not found.");
        }
    }
}