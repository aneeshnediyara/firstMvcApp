using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcApp.Models;

namespace firstMvcApp.Infrastructure
{
    public class ProductRepository : IRepository<Product, int>
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>
            {
            new Product { ProductId=1, ProductName="Soap", UnitPrice=500.50M, UnitsInStock = 10, Discontinued= false},
            new Product { ProductId = 2, ProductName = "Car", UnitPrice = 5000.50M, UnitsInStock = 20, Discontinued = false },
            new Product { ProductId = 3, ProductName = "Bus", UnitPrice = 50.50M, UnitsInStock = 30, Discontinued = false },
            new Product { ProductId = 4, ProductName = "Van", UnitPrice = 5.50M, UnitsInStock = 40, Discontinued = false }
            };
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetDetails(int id)
        {
            return products.FirstOrDefault(c => c.ProductId == id);
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}